using System.Collections.Generic;
using Runtime.Enums;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Runtime.Command.UI
{
    public class UIPanelCommand
    {
        private readonly List<Transform> _layers;
        private AsyncOperationHandle<GameObject> _operationHandle;

        public UIPanelCommand(List<Transform> layers)
        {
            _layers = layers;
        }

        public void Execute(UIPanelTypes panelType, byte panelIndex)
        {
            Undo(panelIndex);
            _operationHandle = Addressables.LoadAssetAsync<GameObject>($"Screens/{panelType}Panel");

            _operationHandle.Completed += asyncOperationHandle =>
            {
                Object.Instantiate(_operationHandle.Result, _layers[panelIndex]);
            };
        }

        private void Undo(byte panelIndex)
        {
            if (_operationHandle.IsValid())
                Addressables.Release(_operationHandle);
#if UNITY_2021_3_38
            if (_layers[panelIndex].childCount > 0)
                Object.DestroyImmediate(_layers[panelIndex].GetChild(0).gameObject);
#else
            if (_layers[panelIndex].childCount > 0)
                Object.Destroy(_layers[panelIndex].GetChild(0).gameObject);
#endif
        }
    }
}