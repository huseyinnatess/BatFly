using System;
using System.Collections.Generic;
using Runtime.Interfaces;
using Runtime.MonoSingleton;
using UnityEngine;

namespace Runtime.Controller.Player
{
    public class PlayerTriggerController : MonoSingleton<PlayerTriggerController>
    {
        private List<IPlayerTriggerObserver> _observers = new();

        public void AddObserver(IPlayerTriggerObserver observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
        }

        public void RemoveObserver(IPlayerTriggerObserver observer)
        {
            if (_observers.Contains(observer))
                _observers.Remove(observer);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            NotifyObservers(other);
        }

        private void NotifyObservers(Collider2D other)
        {
            for (int i = 0; i < _observers.Count; i++)
            {
                _observers[i].OnPlayerTriggered(other);
            }
        }
    }
}