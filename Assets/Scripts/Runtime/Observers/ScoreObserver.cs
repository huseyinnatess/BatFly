using Runtime.Interfaces;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Observers
{
    public class ScoreObserver : IPlayerTriggerObserver
    {
        private ushort _score = 0;

        public void OnPlayerTriggered(Collider2D collider)
        {
            if (collider.CompareTag("ScoreTrigger"))
                UISignals.Instance.onScoreChange?.Invoke(++_score);
        }
    }
}