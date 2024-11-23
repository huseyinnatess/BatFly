using Runtime.Controller.Save;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Manager
{
    public class SaveManager : MonoBehaviour
    {
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onSaveGame += SaveController.Instance.OnSaveData;
        }
        
        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onSaveGame -= SaveController.Instance.OnSaveData;
        }
    }
}