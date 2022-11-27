using UnityEngine;

namespace IbragimovAA.Arcanoid
{
    public class PlatformController : MonoBehaviour
    {
        private Vector3 _moveDirection;
        protected InputSystem _inputSystem;

        protected virtual void OnEnable()
        {
            _inputSystem = new InputSystem();
            _inputSystem.Enable();
        }

        protected void SetMovement(Vector2 direction)
        {
            _moveDirection.x += direction.x;
            _moveDirection.y += direction.y;
        }
        private void Update()
        {
            transform.Translate(Time.deltaTime * _moveDirection);
        }
        private void OnDisable() => _inputSystem.Disable();
    }
}