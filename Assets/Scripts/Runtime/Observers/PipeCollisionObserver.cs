using Runtime.Enums.UI;
using Runtime.Interfaces;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Observers
{
    public class PipeCollisionObserver : IPlayerTriggerObserver
    {
        public void OnPlayerTriggered(Collider2D collider)
        {
            if (!collider.CompareTag("Pipe")) return;
            UISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.GameOver, 1);
            BackgroundSignals.Instance.onStopBackground?.Invoke();
            PlayerSignals.Instance.onDisableCollider?.Invoke();
        }
    }
}