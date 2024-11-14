using System;
using Runtime.Controller.Player;
using Runtime.Interfaces;
using Runtime.Observers;
using UnityEngine;

namespace Runtime.Manager
{
    public class GameManager : MonoBehaviour
    {
        #region Private Variables
        
        private IPlayerTriggerObserver _backgroundResetObserver;

        #endregion

        #region Public Variables

        public PlayerTriggerController _playerTriggerController;

        #endregion

        private void Start()
        {
            _backgroundResetObserver = new BackgroundResetObserver();
            PlayerTriggerController.Instance.AddObserver(_backgroundResetObserver);
        }
    }
}