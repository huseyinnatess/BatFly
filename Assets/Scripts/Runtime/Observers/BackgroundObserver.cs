using Runtime.Interfaces;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Observers
{
    public class BackgroundObserver : IPlayerTriggerObserver
    {
        private string _oldBackgroundTag;
        private bool _isFirstTimeTriggered = true;

        public void OnPlayerTriggered(Collider2D collider)
        {
            string backgroundTag = collider.CompareTag("FirstBackground") ? "FirstBackground" :
                collider.CompareTag("SecondBackground") ? "SecondBackground" : null;
            if (string.IsNullOrEmpty(backgroundTag) || _oldBackgroundTag == backgroundTag) return;
            if (_isFirstTimeTriggered)
            {
                _isFirstTimeTriggered = false;
                return;                
            }
            _oldBackgroundTag = backgroundTag;
            BackgroundSignals.Instance.onSetBackgroundPosition?.Invoke(backgroundTag);
            BackgroundSignals.Instance.onSetPipesHeight?.Invoke(backgroundTag);
        }
    }
}