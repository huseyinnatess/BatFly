using Runtime.MonoSingleton;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class InputSignals : MonoSingleton<InputSignals>
    {
        public UnityAction<bool> onTouched = delegate { };
        public UnityAction<byte> onFirstTimeTouchTaken = delegate { };
    }
}