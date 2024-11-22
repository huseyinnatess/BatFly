using Runtime.Interfaces;
using UnityEngine;

namespace Runtime.Observers
{
    public class PipeCollisionObserver : IPlayerTriggerObserver
    {
        public void OnPlayerTriggered(Collider2D collider)
        {
            if (collider.CompareTag("Pipe"))
            {
                // End Game panel açılacak
            }
        }
    }
}