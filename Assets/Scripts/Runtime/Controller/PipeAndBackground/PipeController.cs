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
        [SerializeField] private PipeAndBackgroundObjects[] pipeObjects;

        #endregion

        #endregion

        public void SetData(PipeSettings pipeData, PipeAndBackgroundObjects[] pipeObjects)
        {
            _settings = pipeData;
            this.pipeObjects = pipeObjects;
        }

        public void SetPipesHeight(string levelTag)
        {
            if (levelTag == "FirstBackground")
                SetHeight(pipeObjects[1].PipeUp, pipeObjects[1].PipeDown);
            else
                SetHeight(pipeObjects[0].PipeUp, pipeObjects[0].PipeDown);
        }

        private void SetHeight(Transform[] pipeUp, Transform[] pipeDown)
        {
            for (int i = 0; i < pipeUp.Length; i++)
            {
                float3 position = pipeUp[i].position;
                pipeUp[i].position =
                    new Vector2(position.x, Random.Range(_settings.MinHeight, _settings.MaxHeight));

                pipeDown[i].position = new Vector2(position.x, pipeUp[i].position.y - _settings.PipeGapHeight);
            }
        }
    }
}