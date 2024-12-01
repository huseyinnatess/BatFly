using Runtime.Data.ValueObjects;
using Runtime.Manager;
using Runtime.MonoSingleton;
using Unity.Mathematics;
using UnityEngine;

namespace Runtime.Controller.PipeAndBackground
{
    public class BackgroundController : MonoSingleton<BackgroundController>
    {
        #region Self Variables

        #region Private Variables

        private Transform _firstBackground;
        private Transform _secondBackground;
        private PipeAndBackgroundObjects[] _backgroundObjects;

        private float3 _scrollSpeed;
        private float _spawnCount;

        private bool _isCanScroll;
        
        #endregion

        #endregion

        public void SetDatas(BackgroundSettings settings, PipeAndBackgroundObjects[] backgroundObjects)
        {
            _firstBackground = backgroundObjects[0].Background;
            _secondBackground = backgroundObjects[1].Background;
            _scrollSpeed = settings.ScrollSpeed * Vector3.left;
            _spawnCount = settings.SpawnCount;
            OnScrollBackground();
        }

        private void Update()
        {
            if (!_isCanScroll) return;
            _firstBackground.transform.Translate(_scrollSpeed * Time.deltaTime);
            _secondBackground.transform.Translate(_scrollSpeed * Time.deltaTime);
        }

        public void OnScrollBackground()
        {
            _isCanScroll = true;
        }

        public void SetBackgroundPosition(string levelTag)
        {
            SetBackgroundPosition(levelTag == "FirstBackground" ? _secondBackground : _firstBackground);
        }

        public void OnStopBackground()
        {
            _isCanScroll = false;
        }

        private void SetBackgroundPosition(Transform background)
        {
            Vector3 position = background.position;
            background.position = new Vector2(position.x + _spawnCount, position.y);

            OnScrollBackground();
        }
    }
}