using UnityEngine;

namespace IbragimovAA.Arcanoid
{
    public class FirstPlayerPlatform : PlatformController
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            _inputSystem.FirstPlatform.Movement.performed += callbackContext => SetMovement(callbackContext.ReadValue<Vector2>());
            //_inputSystem.FirstPlatform.Launch.performed += callbackContext => Player.currentPlayer.Jump();
        }
    }
}
