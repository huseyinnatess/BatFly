using UnityEngine;
using Runtime.Data.ValueObjects;

namespace Runtime.Command.EnvironmentElements
{
    public class EnvironmentElementsCommand
    {
        #region Private Variables

        private EnvironmentElementsData _environmentElementsData;
        private Transform[] _endElementsArray;
        private byte _visibleElementsCount;
        private byte _limit;
        
        #endregion

        public void SetData(EnvironmentElementsData data)
        {
            _environmentElementsData = data;
        }

        public void Execute(Transform[] elements)
        {
            Undo();
            _visibleElementsCount = (byte)(elements.Length / 3 + Random.Range(0, 2));
            _limit = (byte)(elements.Length - 1);
            _endElementsArray = elements;
            
            for (byte i = 0; i < _visibleElementsCount; i++)
            {
                elements[Random.Range(0, _limit)].gameObject.SetActive(true);
            }
        }

        public void Undo()
        {
            if (_endElementsArray == null) return;
            for (byte i = 0; i < _limit; i++)
            {
                _endElementsArray[i].gameObject.SetActive(false);
            }
        }
    }
}