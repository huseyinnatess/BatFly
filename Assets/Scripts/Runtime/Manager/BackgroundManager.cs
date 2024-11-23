using System;
using Runtime.Controller.PipeAndBackground;
using Runtime.Data.UnityObjects;
using Runtime.Data.ValueObjects;
using Runtime.MonoSingleton;
using Runtime.Signals;
using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime.Manager
{
    [Serializable]
    public struct PipeAndBackgroundObjects
    {
        public Transform Background;
        public Transform[] PipeUp;
        public Transform[] PipeDown;
    }

    public class BackgroundManager : MonoSingleton<BackgroundManager>
    {
        #region Self Variables

        #region Serializefield Variables

        [SerializeField] private BackgroundController backgroundController;
        [SerializeField] private PipeController pipeController;

        #endregion

        #region Private Variables

        private LevelElementData _levelElementData;
        [SerializeField] private PipeAndBackgroundObjects[] pipeAndBackgroundObjects;

        #endregion

        #endregion

        protected void Awake()
        {
            SetData();
        }

        private void SendDataToControllers()
        {
            backgroundController.SetDatas(_levelElementData.backgroundSettingses, pipeAndBackgroundObjects);
            pipeController.SetData(_levelElementData.PipeDatas, pipeAndBackgroundObjects);
        }

        private void SetData()
        {
            var request = Resources.LoadAsync<CD_Background>("Data/CD_Background");

            request.completed += operation =>
            {
                if (request.asset is CD_Background cdBackground)
                    _levelElementData = cdBackground.Data;
                SendDataToControllers();
            };
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            BackgroundSignals.Instance.onSetPipesHeight += pipeController.SetPipesHeight;
            BackgroundSignals.Instance.onScrollBackground += backgroundController.ScrollBackground;
            BackgroundSignals.Instance.onSetBackgroundPosition += backgroundController.SetBackgroundPosition;
            BackgroundSignals.Instance.onStopBackground += backgroundController.OnStopBackground;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void UnsubscribeEvents()
        {
            BackgroundSignals.Instance.onSetPipesHeight -= pipeController.SetPipesHeight;
            BackgroundSignals.Instance.onScrollBackground -= backgroundController.ScrollBackground;
            BackgroundSignals.Instance.onSetBackgroundPosition -= backgroundController.SetBackgroundPosition;
            BackgroundSignals.Instance.onStopBackground += backgroundController.OnStopBackground;

        }
    }
}