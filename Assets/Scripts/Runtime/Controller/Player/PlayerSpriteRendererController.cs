using Runtime.Data.ValueObjects;
using Runtime.Enums;
using Runtime.MonoSingleton;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Controller.Player
{
    public class PlayerSpriteRendererController : MonoSingleton<PlayerSpriteRendererController>
    {
        #region Self Variables

        #region Private Variables

        private SpriteRenderer _spriteRenderer;
        private PlayerSpriteData _spriteData;

        #endregion

        #endregion

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void SetData(PlayerSpriteData spriteData)
        {
            _spriteData = spriteData;
        }

        private void UpdateSprite(byte spriteIndex)
        {
            _spriteRenderer.sprite = _spriteData.Sprites[spriteIndex];
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onReset += OnReset;
            PlayerSignals.Instance.onSpriteUpdate += UpdateSprite;
        }

        private void OnReset()
        {
            _spriteRenderer.sprite = _spriteData.Sprites[0];
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onReset -= OnReset;
            PlayerSignals.Instance.onSpriteUpdate -= UpdateSprite;
        }
    }
}