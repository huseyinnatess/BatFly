using DG.Tweening;
using Runtime.Data.ValueObjects;
using Runtime.Enums;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Controller.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        #region Self Variables

        #region Serializefield Variables

        [SerializeField] private new Rigidbody2D rigidbody;

        #region Private Variables

        private PlayerMovementData _movementData;
        private bool _isTouched;

        #endregion

        #endregion

        #endregion

        public void SetData(PlayerMovementData movementData)
        {
            _movementData = movementData;
        }

        private void FixedUpdate()
        {
            if (!_isTouched) return;
            Jump();
            StartRotationAnimation();
            StartHeightAnimation();
            _isTouched = false;
        }

        private void Jump()
        {
            rigidbody.AddForce(Vector2.up * _movementData.JumpForce, ForceMode2D.Impulse);
        }

        private void StartHeightAnimation()
        {
            rigidbody.DOMoveY(rigidbody.position.y + _movementData.JumpHeight, _movementData.JumpDuration)
                .SetEase(Ease.OutQuad)
                .OnComplete(() => { rigidbody.velocity = Vector2.zero; });
        }
        
        private void StartRotationAnimation()
        {
            float startRotation = transform.parent.parent.rotation.z;
            PlayerSignals.Instance.onPlayerSpriteUpdate?.Invoke((byte)PlayerSprite.UpFlap);

            rigidbody
                .DORotate(startRotation + _movementData.RotationCount, _movementData.JumpDuration)
                .SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    PlayerSignals.Instance.onPlayerSpriteUpdate?.Invoke((byte)PlayerSprite.DownFlap);
                    rigidbody.DORotate(startRotation - _movementData.RotationCount * 2, _movementData.JumpDuration)
                        .SetEase(Ease.OutQuad);
                });
        }

        public void IsTouched()
        {
            _isTouched = true;
        }

        public void SetPlayerGravity()
        {
            rigidbody.gravityScale = 1;
        }

        public void OnReset()
        {
            _isTouched = false;
        }
    }
}