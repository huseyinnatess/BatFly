using Runtime.MonoSingleton;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class InputSignals : MonoSingleton<InputSignals>
    {
        public UnityAction onTouched = delegate { };
        public UnityAction onFirstTimeTouchTaken = delegate { };
    }
}