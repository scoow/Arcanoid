using UnityEngine;

namespace IbragimovAA.Arcanoid
{
    public class SecondPlayerPlatform : PlatformController
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            _inputSystem.SecondPlatform.Movement.performed += callbackContext => SetMovement(callbackContext.ReadValue<Vector2>());
        }
    }
}
