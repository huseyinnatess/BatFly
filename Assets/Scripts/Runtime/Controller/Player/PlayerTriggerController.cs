using System.Collections.Generic;
using Runtime.Interfaces;
using UnityEngine;

namespace Runtime.Controller.Player
{
    public class PlayerTriggerController : MonoBehaviour
    {
        public static PlayerTriggerController Instance;
        private readonly List<IPlayerTriggerObserver> _observers = new();
        [SerializeField] private Collider2D collider2D;

        #region Singleton

        private void Awake()
        {
            Singleton();
        }

        private void Singleton()
        {
            if (Instance != this && Instance != null)
            {
                Destroy(this);
                return;
            }

            Instance = this;
        }

        #endregion
        

        public void OnDisablePlayerCollider()
        {
            collider2D.enabled = false;
        }
        
        public void AddObserver(IPlayerTriggerObserver observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
        }

        public void OnReset()
        {
            collider2D.enabled = true;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            NotifyObservers(other);
        }

        private void NotifyObservers(Collider2D other)
        {
            for (byte i = 0; i < _observers.Count; i++)
            {
                _observers[i].OnPlayerTriggered(other);
            }
        }
    }
}