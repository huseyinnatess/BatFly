using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class AudioSignals : MonoBehaviour
    {
        public static AudioSignals Instance;

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

        public UnityAction onDieAudio = delegate { };
        public UnityAction onWingAudio = delegate { };
        public UnityAction onSuccessAudio = delegate { };
    }
}