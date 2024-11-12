using DG.Tweening;
using Runtime.Data.ValueObjects;
using UnityEngine;

namespace Runtime.Controller.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        #region Self Variables

        #region Serializefield Variables

        [SerializeField] private new Rigidbody rigidbody;

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
            _isTouched = false;
        }

        private void Jump()
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(Vector3.up * _movementData.JumpForce, ForceMode.Impulse);

            rigidbody.DOMoveY(rigidbody.position.y + _movementData.JumpHeight, _movementData.JumpDuration)
                .SetEase(Ease.OutQuad);
        }

        public void IsTouched()
        {
            _isTouched = true;
        }

        public void SetPlayerGravity()
        {
            rigidbody.useGravity = true;
        }

        public void OnReset()
        {
            _isTouched = false;
        }
    }
}