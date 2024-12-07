using Runtime.MonoSingleton;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public UnityAction onSaveGame = delegate { };
        public UnityAction onReset = delegate { };
    }
}