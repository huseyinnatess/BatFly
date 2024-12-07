using System;
using Runtime.Command.UI;
using Runtime.Controller.UI;
using Runtime.Enums.UI;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Manager
{
    public class UIManager : MonoBehaviour
    {
        #region Self Variables

        #region Serializefiled Variables

        [SerializeField] private Transform[] uiPanelLayers;

        #endregion

        #region Private Variables

        private UIPanelCommand _uiPanelCommand;

        #endregion

        #endregion

        private void Awake()
        {
            _uiPanelCommand = new UIPanelCommand(uiPanelLayers);
        }

        private void Start()
        {
            ActivateStartPanel();
        }

        private void ActivateStartPanel()
        {
            UISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Start, 0);
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.Instance.onOpenPanel += _uiPanelCommand.Execute;
            UISignals.Instance.onClosePanel += _uiPanelCommand.Undo;
            CoreGameSignals.Instance.onReset += _uiPanelCommand.OnReset;
            UISignals.Instance.onScoreChange += ScoreController.Instance.OnScoreChange;
            CoreGameSignals.Instance.onReset += ScoreController.Instance.OnReset;
            UISignals.Instance.onGetScore += ScoreController.Instance.OnGetScore;
        }

        public void OnPlay()
        {
            UISignals.Instance.onClosePanel?.Invoke(0);
            BackgroundSignals.Instance.onScrollBackground?.Invoke();
            BackgroundSignals.Instance.onSetPipesHeight?.Invoke("FirstBackground");
            BackgroundSignals.Instance.onSetPipesHeight?.Invoke("SecondBackground");
        }
    }
}