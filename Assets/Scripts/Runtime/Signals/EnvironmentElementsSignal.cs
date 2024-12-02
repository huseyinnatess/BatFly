using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class EnvironmentElementsSignal : MonoBehaviour
    {
        public static EnvironmentElementsSignal Instance;

        private void Awake()
        {
            Singleton();
        }

        private void Singleton()
        {
            if (Instance != this && Instance != null)
            {
                Destroy(this);
                return;
            }

            Instance = this;
        }

        public UnityAction<string> onActivateElements = delegate { };
        public UnityAction onDeactivateElements = delegate { };
    }
}