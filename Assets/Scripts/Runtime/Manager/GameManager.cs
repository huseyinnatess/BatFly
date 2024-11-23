using Runtime.Controller.Player;
using Runtime.Interfaces;
using Runtime.Observers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime.Manager
{
    public class GameManager : MonoBehaviour
    {
        #region SerializeField Variables

        [SerializeField ]private PlayerTriggerController playerTriggerController;

        #endregion

        #region Private Variables

        private IPlayerTriggerObserver _backgroundResetObserver;
        private IPlayerTriggerObserver _scoreObserver;
        private IPlayerTriggerObserver _pipeCollisionObserver;

        #endregion


        private void Start()
        {
            CreateObserver();
            AddObserver();
        }
        private void CreateObserver()
        {
            _backgroundResetObserver = new BackgroundObserver();
            _scoreObserver = new ScoreObserver();
            _pipeCollisionObserver = new PipeCollisionObserver();
        }

        private void AddObserver()
        {
            PlayerTriggerController.Instance.AddObserver(_backgroundResetObserver);
            PlayerTriggerController.Instance.AddObserver(_scoreObserver);
            PlayerTriggerController.Instance.AddObserver(_pipeCollisionObserver);
        }

    }
}