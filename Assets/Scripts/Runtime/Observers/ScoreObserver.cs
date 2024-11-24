using Runtime.Interfaces;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Observers
{
    public class ScoreObserver : IPlayerTriggerObserver, IResettableObserver
    {
        private ushort _score = 0;
        private string _oldParentName;
        public void OnPlayerTriggered(Collider2D collider)
        {
            string parentName = collider.transform.parent.name;
            if (!collider.CompareTag("ScoreTrigger") || _oldParentName == parentName
                || string.IsNullOrEmpty(_oldParentName)) return;
            _oldParentName = parentName;
            UISignals.Instance.onScoreChange?.Invoke(++_score);
        }

        public void OnReset()
        {
            _score = 0;
            _oldParentName = null;
        }
    }
}