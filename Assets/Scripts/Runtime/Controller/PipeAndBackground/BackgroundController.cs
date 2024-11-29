using DG.Tweening;
using Runtime.Data.ValueObjects;
using Runtime.Manager;
using Runtime.MonoSingleton;
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

        private float _scrollSpeed;
        private float _spawnCount;
        
        #endregion

        #endregion

        public void SetDatas(BackgroundSettings settings, PipeAndBackgroundObjects[] backgroundObjects)
        {
            _firstBackground = backgroundObjects[0].Background;
            _secondBackground = backgroundObjects[1].Background;
            _scrollSpeed = settings.ScrollSpeed;
            _spawnCount = settings.SpawnCount;
        }
        
        public void ScrollBackground()
        {
            _firstBackground
                .DOMoveX(-50, _scrollSpeed)
                .SetRelative()
                .SetEase(Ease.Linear);

            _secondBackground
                .DOMoveX(-50, _scrollSpeed)
                .SetRelative()
                .SetEase(Ease.Linear);
        }

        public void SetBackgroundPosition(string levelTag)
        {
            SetBackgroundPosition(levelTag == "FirstBackground" ? _secondBackground : _firstBackground);
        }

        public void OnStopBackground()
        {
            DOTween.KillAll();
        }

        private void SetBackgroundPosition(Transform background)
        {
            DOTween.Kill(background);

            Vector3 position = background.position;
            background.position = new Vector2(position.x + _spawnCount, position.y);

            ScrollBackground();
        }
    }
}