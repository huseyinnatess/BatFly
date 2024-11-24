using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class BackgroundSignals : MonoBehaviour
    {
        public static BackgroundSignals Instance;

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

        public UnityAction<string> onSetPipesHeight = delegate { };
        public UnityAction onScrollBackground = delegate { };
        public UnityAction onStopBackground = delegate { };
        public UnityAction<string> onSetBackgroundPosition = delegate { };
        public UnityAction onActivatePipes = delegate {};
    }
}