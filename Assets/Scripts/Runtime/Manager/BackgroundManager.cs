using System;
using Runtime.Controller.PipeAndBackground;
using Runtime.Data.UnityObjects;
using Runtime.Data.ValueObjects;
using Runtime.MonoSingleton;
using Runtime.Signals;
using UnityEngine;

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
        [SerializeField] private PipeAndBackgroundObjects[] _pipeAndBackgroundObjects;

        #endregion

        #endregion

        protected void Awake()
        {
            SetData();
            SendDataToControllers();
        }

        private void SendDataToControllers()
        {
            backgroundController.SetDatas(_levelElementData.backgroundSettingses, _pipeAndBackgroundObjects);
            pipeController.SetData(_levelElementData.PipeDatas, _pipeAndBackgroundObjects);
        }

        private void SetData()
        {
            _levelElementData = Resources.Load<CD_Background>("Data/CD_Background").Data;
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
        }
    }
}