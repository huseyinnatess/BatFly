using Runtime.Interfaces;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Observers
{
    public class BackgroundResetObserver : IPlayerTriggerObserver
    {
        public void OnPlayerTriggered(Collider2D collider)
        {
            if (collider.CompareTag("FirstBackground"))
            {
                BackgroundSignals.Instance.onSetBackgroundPosition?.Invoke("FirstBackground");
                BackgroundSignals.Instance.onSetPipesHeight?.Invoke("FirstBackground");
            }
            else if (collider.CompareTag("SecondBackground"))
            {
                BackgroundSignals.Instance.onSetBackgroundPosition?.Invoke("SecondBackground");
                BackgroundSignals.Instance.onSetPipesHeight?.Invoke("SecondBackground");
            }
        }
    }
}