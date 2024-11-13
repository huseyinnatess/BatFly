using System;
using Runtime.Controller.Player;
using Runtime.Data.UnityObjects;
using Runtime.Data.ValueObjects;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Manager
{
    public class PlayerManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerMovementController movementController;
        [SerializeField] private PlayerSpriteRendererController spriteRendererController;

        #endregion

        #region Private Variables

        private PlayerData _playerData;

        #endregion

        #endregion

        private void Awake()
        {
            SetPlayerData();
        }

        private void SetPlayerData()
        {
            var request = Resources.LoadAsync<CD_Player>("Data/CD_Player");
            
            request.completed += operation =>
            {
                if (request.asset is not CD_Player cdPlayer) return;
                movementController.SetData(cdPlayer.Data.MovementData);
                spriteRendererController.SetData(cdPlayer.Data.SpriteData);
            };
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            InputSignals.Instance.onTouched += movementController.IsTouched;
            InputSignals.Instance.onFirstTimeTouchTaken += movementController.SetPlayerGravity;
            CoreGameSignals.Instance.onReset += movementController.OnReset;
        }
        
        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void UnsubscribeEvents()
        {
            InputSignals.Instance.onTouched -= movementController.IsTouched;
            InputSignals.Instance.onFirstTimeTouchTaken -= movementController.SetPlayerGravity;
            CoreGameSignals.Instance.onReset -= movementController.OnReset;
        }
    }
}