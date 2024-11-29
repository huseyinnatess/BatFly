using System;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Manager
{
    public class AudioManager : MonoBehaviour
    {
        #region Self Variables

        #region Serializefield Variables

        [SerializeField] private AudioSource dieAuido;
        [SerializeField] private AudioSource wingAuido;
        [SerializeField] private AudioSource successAuido;

        #endregion

        #endregion

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            AudioSignals.Instance.onDieAudio += OnDieAudio;
            AudioSignals.Instance.onWingAudio += OnWingAudio;
            AudioSignals.Instance.onSuccessAudio += OnSuccessAudio;
        }

        private void OnDieAudio()
        {
            dieAuido.Play();
        }
        
        private void OnWingAudio()
        {
            wingAuido.Play();
        }
        
        private void OnSuccessAudio()
        {
            successAuido.Play();
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void UnsubscribeEvents()
        {
            AudioSignals.Instance.onDieAudio -= OnDieAudio;
            AudioSignals.Instance.onWingAudio -= OnWingAudio;
            AudioSignals.Instance.onSuccessAudio -= OnSuccessAudio;
        }
    }
}