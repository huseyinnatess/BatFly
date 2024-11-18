using Runtime.Interfaces;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Observers
{
    public class ScoreObserver : IPlayerTriggerObserver
    {
        private ushort _score = 0;
        private string _oldParentName;
        public void OnPlayerTriggered(Collider2D collider)
        {
            string parentName = collider.transform.parent.name;
            if (collider.CompareTag("ScoreTrigger") && _oldParentName != parentName)
            {
                _oldParentName = parentName;
                UISignals.Instance.onScoreChange?.Invoke(++_score);
            }
        }
    }
}