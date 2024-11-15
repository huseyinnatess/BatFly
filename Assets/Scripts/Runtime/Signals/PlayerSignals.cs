using Runtime.Enums;
using Runtime.MonoSingleton;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class PlayerSignals : MonoBehaviour
    {
        public static PlayerSignals Instance;

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
        public UnityAction<byte> onSpriteUpdate = delegate { };
    }
}