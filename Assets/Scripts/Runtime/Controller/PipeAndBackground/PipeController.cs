using Runtime.Data.ValueObjects;
using Runtime.Manager;
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

        private PipeSettings _settings;
        private PipeAndBackgroundObjects[] _pipeObjects;

        #endregion

        #endregion

        public void SetData(PipeSettings pipeData, PipeAndBackgroundObjects[] pipeObjects)
        {
            _settings = pipeData;
            _pipeObjects = pipeObjects;
        }

        public void OnSetPipesHeight(string levelTag)
        {
            if (levelTag == "FirstBackground")
                SetHeight(_pipeObjects[1].PipeUp, _pipeObjects[1].PipeDown);
            else
                SetHeight(_pipeObjects[0].PipeUp, _pipeObjects[0].PipeDown);
        }

        public void OnActivatePipes()
        {
            OnSetPipesStatus(true);
        }


        public void OnReset()
        {
            OnSetPipesStatus(false);
        }

        private void OnSetPipesStatus(bool status)
        {
            var pipesUp = _pipeObjects[0].PipeUp;
            var pipesDown = _pipeObjects[0].PipeDown;

            for (byte i = 0; i < 3; i++)
            {
                pipesUp[i].gameObject.SetActive(status);
                pipesDown[i].gameObject.SetActive(status);
            }
        }
        
        private void SetHeight(Transform[] pipeUp, Transform[] pipeDown)
        {
            for (byte i = 0; i < pipeUp.Length; i++)
            {
                float3 position = pipeUp[i].position;
                pipeUp[i].position =
                    new Vector2(position.x, Random.Range(_settings.MinHeight, _settings.MaxHeight));

                pipeDown[i].position = new Vector2(position.x, pipeUp[i].position.y - _settings.PipeGapHeight);
            }

        }
    }
}