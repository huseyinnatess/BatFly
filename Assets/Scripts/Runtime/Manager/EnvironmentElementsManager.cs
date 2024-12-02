using Runtime.Command.EnvironmentElements;
using Runtime.Data.ValueObjects;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Manager
{
    public class EnvironmentElementsManager : MonoBehaviour
    {
        #region Self Variables

        #region Serializefield Variables

        [SerializeField] EnvironmentElementsData elementsData;

        #endregion


        #region Private Variables

        private EnvironmentElementsCommand _elementsCommand;

        #endregion

        #endregion

        private void Awake()
        {
            _elementsCommand = new EnvironmentElementsCommand();
            SendDataToController();
        }

        private void SendDataToController()
        {
            _elementsCommand.SetData(elementsData);
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void OnActivateElements(string backgroundTag)
        {
            _elementsCommand.Execute(backgroundTag == "FirstBackground"
                ? elementsData.SecondBackgroundElements
                : elementsData.FirstBackgroundElements);
        }

        private void OnReset()
        {
            _elementsCommand.Undo();
        }

        private void SubscribeEvents()
        {
            EnvironmentElementsSignal.Instance.onActivateElements += OnActivateElements;
            EnvironmentElementsSignal.Instance.onDeactivateElements += _elementsCommand.Undo;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void UnsubscribeEvents()
        {
            EnvironmentElementsSignal.Instance.onActivateElements -= OnActivateElements;
            EnvironmentElementsSignal.Instance.onDeactivateElements -= _elementsCommand.Undo;
            CoreGameSignals.Instance.onReset -= OnReset;
        }
    }
}