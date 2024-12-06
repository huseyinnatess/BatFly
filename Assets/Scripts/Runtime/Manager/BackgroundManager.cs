using System;
using Runtime.Controller.PipeAndBackground;
using Runtime.Data.UnityObjects;
using Runtime.Data.ValueObjects;
using Runtime.MonoSingleton;
using Runtime.Signals;
using Unity.Mathematics;
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
        public float3 Position;
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

        private void Awake()
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

            request.completed += _ =>
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
        
        private void SetDefaultPositions()
        {
            for (byte i = 0; i < pipeAndBackgroundObjects.Length; i++)
            {
                var objects = pipeAndBackgroundObjects[i];
                objects.Background.position = objects.Position;
            }
        }
        
        private void OnReset()
        {
            SetDefaultPositions();
            backgroundController.OnScrollBackground();
        }
        
        private void SubscribeEvents()
        {
            BackgroundSignals.Instance.onSetPipesHeight += pipeController.OnSetPipesHeight;
            BackgroundSignals.Instance.onScrollBackground += backgroundController.OnScrollBackground;
            BackgroundSignals.Instance.onSetBackgroundPosition += backgroundController.OnSetBackgroundPosition;
            BackgroundSignals.Instance.onStopBackground += backgroundController.OnStopBackground;
            BackgroundSignals.Instance.onActivatePipes += pipeController.OnActivatePipes;
            CoreGameSignals.Instance.onReset += pipeController.OnReset;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void UnsubscribeEvents()
        {
            BackgroundSignals.Instance.onSetPipesHeight -= pipeController.OnSetPipesHeight;
            BackgroundSignals.Instance.onScrollBackground -= backgroundController.OnScrollBackground;
            BackgroundSignals.Instance.onSetBackgroundPosition -= backgroundController.OnSetBackgroundPosition;
            BackgroundSignals.Instance.onStopBackground += backgroundController.OnStopBackground;
            CoreGameSignals.Instance.onReset -= pipeController.OnReset;
            CoreGameSignals.Instance.onReset -= OnReset;
        }
    }
}