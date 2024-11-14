using UnityEngine;

namespace Runtime.Interfaces
{
    public interface IPlayerTriggerObserver
    {
        void OnPlayerTriggered(Collider2D collider);
    }
}