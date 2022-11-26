using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace IbragimovAA.Arcanoid
{
    public class PlatformController : MonoBehaviour
    {
        private InputSystem _inputSystem;
        private void OnEnable()
        {
            _inputSystem = new InputSystem();
            _inputSystem.Enable();

            _inputSystem.Platform.WASD.performed += callbackContext => SetMovement(callbackContext.ReadValue<Vector2>().x, callbackContext.ReadValue<Vector2>().y);
        }

        private void SetMovement(float horizontal, float vertical)
        {
/*            movementVector.x = horizontal * movementSpeed;
            movementVector.z = vertical * movementSpeed;*/
        }
    }
}
