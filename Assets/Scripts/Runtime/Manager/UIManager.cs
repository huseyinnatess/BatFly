using System;
using Runtime.Command.UI;
using Runtime.Controller.UI;
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

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.Instance.onScoreChange += ScoreController.Instance.OnScoreChange;
            UISignals.Instance.onOpenPanel += _uiPanelCommand.Execute;
            UISignals.Instance.onClosePanel += _uiPanelCommand.Undo;
            UISignals.Instance.onGetScore += ScoreController.Instance.OnGetScore;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void UnsubscribeEvents()
        {
            UISignals.Instance.onScoreChange -= ScoreController.Instance.OnScoreChange;
            UISignals.Instance.onOpenPanel -= _uiPanelCommand.Execute;
            UISignals.Instance.onClosePanel -= _uiPanelCommand.Undo;
            UISignals.Instance.onGetScore -= ScoreController.Instance.OnGetScore;
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