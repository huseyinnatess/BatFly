using Runtime.MonoSingleton;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class BackgroundSignals : MonoSingleton<BackgroundSignals>
    {
        public UnityAction<string> onSetPipesHeight = delegate { };
        public UnityAction onScrollBackground = delegate { };
        public UnityAction onStopBackground = delegate { };
        public UnityAction<string> onSetBackgroundPosition = delegate { };
        public UnityAction onActivatePipes = delegate {};
    }
}