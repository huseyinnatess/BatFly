using System;
using Runtime.Data.ValueObjects;
using Runtime.MonoSingleton;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.Controller.PipeAndBackground
{
    public class PipeController : MonoSingleton<PipeController>
    {
        #region Self Variables

        #region Private Variables

        private PipeValues _values;
        private PipeObjects[] _objects;

        #endregion

        #endregion
        
        public void SetData(PipeDatas data)
        {
            _values = data.PipeValues;
            _objects = data.PipeObjects;
        }

        public void SetPipesHeight(string levelTag)
        {
            if (levelTag == "FirstBackground")
                SetHeight(_objects[1].PipeUp, _objects[1].PipeDown);
            else
                SetHeight(_objects[0].PipeUp, _objects[0].PipeDown);
        }

        private void SetHeight(GameObject[] pipeUp, GameObject[] pipeDown)
        {
            for (int i = 0; i < pipeUp.Length; i++)
            {
                float3 position = pipeUp[i].transform.position;
                pipeUp[i].transform.position =
                    new Vector2(position.x, Random.Range(_values.MinHeight, _values.MaxHeight));

                pipeDown[i].transform.position = new Vector2(position.x, pipeUp[i].transform.position.y - _values.PipeGapHeight);
            }
        }
    }
}