using System;
using Runtime.Enums;
using Runtime.Enums.UI;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class UISignals : MonoBehaviour
    {
        public static UISignals Instance;

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

        public UnityAction<ushort> onScoreChange = delegate { };
        public UnityAction<UIPanelTypes, byte> onOpenPanel = delegate { };
        public UnityAction<byte> onClosePanel = delegate { };
        public UnityAction onWriteScores = delegate { };
        public Func<ushort> onGetScore = null;
    }
}