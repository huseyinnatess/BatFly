using System;
using System.Collections.Generic;
using Runtime.Signals;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Runtime.Manager
{
    public class InputManager : MonoBehaviour
    {
        #region Self Variables

        #region Private Variables

        private bool _isFirstTimeTouchTaken = false;

        #endregion

        #endregion

        private void OnEnable()
        {
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void OnReset()
        {
            _isFirstTimeTouchTaken = false;
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0) || IsPointerOverUIElement()) return;
            if (!_isFirstTimeTouchTaken)
            {
                InputSignals.Instance.onFirstTimeTouchTaken?.Invoke();
                InputSignals.Instance.onTouched?.Invoke();
                _isFirstTimeTouchTaken = true;
            }
            else
                InputSignals.Instance.onTouched?.Invoke();
        }

        private bool IsPointerOverUIElement()
        {
            return EventSystem.current.IsPointerOverGameObject();
        }

        private void OnDisable()
        {
            CoreGameSignals.Instance.onReset -= OnReset;
        }
    }
}