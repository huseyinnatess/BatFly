using Runtime.MonoSingleton;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class BackgroundSignals : MonoSingleton<BackgroundSignals>
    {
        public UnityAction onBackgroundEndReached = delegate { };
        public UnityAction<string> onSetPipesHeight = delegate { };
        public UnityAction onScrollBackground = delegate { };
        public UnityAction<string> onSetBackgroundPosition = delegate { };
    }
}