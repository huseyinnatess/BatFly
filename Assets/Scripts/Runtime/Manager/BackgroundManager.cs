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
    public class BackgroundManager : MonoSingleton<BackgroundManager>
    {
        #region Self Variables

        #region Serializefield Variables

        [SerializeField] private BackgroundController backgroundController;
        [SerializeField] private PipeController pipeController;

        #endregion

        #region Private Variables

        private LevelElementData _levelElementData;

        #endregion

        #endregion

        protected override void Awake()
        {
            base.Awake();
            SetData();
            SendDataToControllers();
        }
        
        private void SendDataToControllers()
        {
            backgroundController.SetDatas(_levelElementData.BackgroundDatas);
            pipeController.SetData(_levelElementData.PipeDatas);
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
    }
}