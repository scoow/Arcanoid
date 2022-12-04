using UnityEngine;

namespace IbragimovAA.Arcanoid
{
    public class FirstPlayerPlatform : PlatformController
    {
        private UIManager _UIManager;
        protected override void OnEnable()
        {
            base.OnEnable();
            _inputSystem.FirstPlatform.Movement.performed += callbackContext => SetMovement(callbackContext.ReadValue<Vector2>());
            _inputSystem.FirstPlatform.Launch.performed += callbackContext => GameManager.instance.StartGame();

            _UIManager = FindObjectOfType<UIManager>();
            _inputSystem.FirstPlatform.Pause.performed += callbackContext => _UIManager.PauseGame();
        }
    }
}