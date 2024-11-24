using System;
using Runtime.Controller.Player;
using Runtime.Interfaces;
using Runtime.Observers;
using Runtime.Signals;
using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime.Manager
{
    public class GameManager : MonoBehaviour
    {
        #region SerializeField Variables

        [SerializeField] private PlayerTriggerController playerTriggerController;

        #endregion

        #region Private Variables

        private IPlayerTriggerObserver _backgroundObserver;
        private IPlayerTriggerObserver _scoreObserver;
        private IPlayerTriggerObserver _pipeCollisionObserver;

        #endregion

        private void Start()
        {
            CreateObserver();
            AddObserver();
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onReset += () => InvokeOnReset(_backgroundObserver);
            CoreGameSignals.Instance.onReset += () => InvokeOnReset(_scoreObserver);
        }  
        
        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onReset -= () => InvokeOnReset(_backgroundObserver);
            CoreGameSignals.Instance.onReset -= () => InvokeOnReset(_scoreObserver);
        }

        private void CreateObserver()
        {
            _backgroundObserver = new BackgroundObserver();
            _scoreObserver = new ScoreObserver();
            _pipeCollisionObserver = new PipeCollisionObserver();
        }

        private void AddObserver()
        {
            PlayerTriggerController.Instance.AddObserver(_backgroundObserver);
            PlayerTriggerController.Instance.AddObserver(_scoreObserver);
            PlayerTriggerController.Instance.AddObserver(_pipeCollisionObserver);
        }

        private void InvokeOnReset<T>(T baseClass)
        {
            if (baseClass is IResettableObserver observer)
            {
                observer.OnReset();
            }
        }
    }
}