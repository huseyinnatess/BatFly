using Runtime.Enums;
using Runtime.MonoSingleton;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class PlayerSignals : MonoSingleton<PlayerSignals>
    {
        public UnityAction<byte> onSpriteUpdate = delegate { };
    }
}