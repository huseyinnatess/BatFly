using DG.Tweening;
using Runtime.Data.UnityObjects;
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

        private bool _isTouched;

        private PlayerMovementData _movementData;

        #endregion

        #endregion

        #endregion


        private void Awake()
        {
            _isTouched = false;
        }

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _movementData = Resources.Load<CD_Player>("Data/CD_Player").Data.MovementData;
        }

        private void FixedUpdate()
        {
            if (!_isTouched) return;
            Jump();
            _isTouched = false;
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            _isTouched = true;
        }

        private void Jump()
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(Vector3.up * _movementData.JumpForce, ForceMode.Impulse);

            rigidbody.DOMoveY(rigidbody.position.y + _movementData.JumpHeight, _movementData.JumpDuration)
                .SetEase(Ease.OutQuad);
        }
    }
}