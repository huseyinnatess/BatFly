using System;
using Runtime.Enums.UI;
using Runtime.Manager;
using Runtime.Signals;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Handlers
{
    public class UIEventSubscriber : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private UIEventSubscriptionTypes type;
        [SerializeField] private Button button;

        #endregion

        #region Private Variables

        [ShowInInspector] private UIManager _manager;

        #endregion

        #endregion

        private void Awake()
        {
            FindObject();
        }

        private void FindObject()
        {
            _manager = FindObjectOfType<UIManager>();
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            switch (type)
            {
                case UIEventSubscriptionTypes.OnPlay:
                    button.onClick.AddListener(_manager.OnPlay);
                    break;
                case UIEventSubscriptionTypes.OnRestart:
                    button.onClick.AddListener(() => CoreGameSignals.Instance.onReset?.Invoke());
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void OnDisable()
        {
            UnubscribeEvents();
        }

        private void UnubscribeEvents()
        {
            button.onClick.RemoveAllListeners();
        }
    }
}