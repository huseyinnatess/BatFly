using System.Collections.Generic;
using Runtime.Enums;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Runtime.Controller.UI
{
    public class UIPanelController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public static UIPanelController Instance;

        #endregion

        #region Serializefield Variables

        [SerializeField] private List<Transform> layers = new();

        #endregion

        #region Private Variables

        private AsyncOperationHandle<GameObject> _operationHandle;

        #endregion

        #endregion

        private void Awake()
        {
            Singleton();
        }

        private void Singleton()
        {
            if (Instance != this && Instance != null)
            {
                Destroy(this);
                return;
            }

            Instance = this;
        }

        [Button("Open Panel")]
        public void OnOpenPanel(UIPanelTypes panelType, byte panelIndex)
        {
            ClosePanel(panelIndex);
            _operationHandle = Addressables.LoadAssetAsync<GameObject>($"Screens/{panelType}Panel");

            _operationHandle.Completed += asyncOperationHandle =>
            {
                Instantiate(_operationHandle.Result, layers[panelIndex]);
            };
        }

        private void ClosePanel(byte panelIndex)
        {
            if (_operationHandle.IsValid())
                Addressables.Release(_operationHandle);
#if UNITY_2021_3_38
            if (layers[panelIndex].childCount > 0)
                DestroyImmediate(layers[panelIndex].GetChild(0).gameObject);
#else
            if (layers[panelIndex].childCount > 0)
                Destroy(layers[panelIndex].GetChild(0).gameObject);
#endif
        }
    }
}