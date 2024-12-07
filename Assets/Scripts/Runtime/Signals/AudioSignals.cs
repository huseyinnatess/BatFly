using Runtime.MonoSingleton;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class AudioSignals : MonoSingleton<AudioSignals>
    {
        public UnityAction onDieAudio = delegate { };
        public UnityAction onWingAudio = delegate { };
        public UnityAction onSuccessAudio = delegate { };
    }
}