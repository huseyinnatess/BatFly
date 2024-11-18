using Runtime.Controller.Player;
using Runtime.Interfaces;
using Runtime.Observers;
using UnityEngine;

namespace Runtime.Manager
{
    public class GameManager : MonoBehaviour
    {
        #region Public Variables

        public PlayerTriggerController _playerTriggerController;

        #endregion

        #region Private Variables

        private IPlayerTriggerObserver _backgroundResetObserver;
        private IPlayerTriggerObserver _scoreObserver;

        #endregion


        private void Start()
        {
            _backgroundResetObserver = new BackgroundObserver();
            _scoreObserver = new ScoreObserver();
            PlayerTriggerController.Instance.AddObserver(_backgroundResetObserver);
            PlayerTriggerController.Instance.AddObserver(_scoreObserver);
        }
    }
}