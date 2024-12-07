using System;
using Runtime.Enums;
using Runtime.Enums.UI;
using Runtime.MonoSingleton;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class UISignals : MonoSingleton<UISignals>
    {
        public UnityAction<ushort> onScoreChange = delegate { };
        public UnityAction<UIPanelTypes, byte> onOpenPanel = delegate { };
        public UnityAction<byte> onClosePanel = delegate { };
        public Func<ushort> onGetScore = null;
    }
}