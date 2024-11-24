using Runtime.Enums.UI;
using UnityEngine;

namespace Runtime.Command.UI
{
    public class UIPanelCommand
    {
        private readonly Transform[] _layers;
        public UIPanelCommand(Transform[] layers)
        {
            _layers = layers;
        }

        public void Execute(UIPanelTypes panelType, byte panelIndex)
        {
            Undo(panelIndex);
            var request = Resources.LoadAsync<GameObject>($"Screens/{panelType}Panel");

            request.completed += handle =>
            {
                Object.Instantiate(request.asset, _layers[panelIndex]);
            };
        }

        public void Undo(byte panelIndex)
        {
            if (_layers[panelIndex].childCount > 0)
                Object.Destroy(_layers[panelIndex].GetChild(0).gameObject);
        }

        public void OnReset()
        {
            Undo(1);
        }
    }
}