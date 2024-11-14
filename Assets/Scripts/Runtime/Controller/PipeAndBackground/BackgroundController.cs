using System;
using DG.Tweening;
using Runtime.Data.ValueObjects;
using Runtime.MonoSingleton;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;

namespace Runtime.Controller.PipeAndBackground
{
    public class BackgroundController : MonoSingleton<BackgroundController>
    {
        #region Self Variables

        #region Private Variables

        private BackgroundData _firstBackground;
        private BackgroundData _secondBackground;

        private float _scrollSpeed;
        private float _spawnCount;

        #endregion

        #endregion

        public void SetDatas(BackgroundData[] data)
        {
            _firstBackground = data[0];
            _secondBackground = data[1];
            _scrollSpeed = _firstBackground.ScrollSpeed;
            _spawnCount = _firstBackground.SpawnCount;
            ScrollBackground();
        }

        public void ScrollBackground()
        {
            _firstBackground.Background
                .DOMoveX(-50, _scrollSpeed)
                .SetRelative()
                .SetEase(Ease.Linear);

            _secondBackground.Background
                .DOMoveX(-50, _scrollSpeed)
                .SetRelative()
                .SetEase(Ease.Linear);
        }

        public void SetBackgroundPosition(string levelTag)
        {
            SetBackgroundPosition(levelTag == "FirstBackground" ? _secondBackground : _firstBackground);
        }

        private void SetBackgroundPosition(BackgroundData data)
        {
            DOTween.Kill(data.Background);

            Vector3 position = data.Background.position;
            data.Background.position = new Vector2(position.x + _spawnCount, position.y);

            ScrollBackground();
        }
    }
}