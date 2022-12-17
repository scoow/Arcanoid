using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace IbragimovAA.Arcanoid
{
    public class UIManager : MonoBehaviour
    {
        private Button _buttonNewGame;
        private Button _buttonResumeGame;
        private Button _buttonSettings;
        private Button _buttonQuit;

        private Canvas _canvas;
        private void Awake()
        {
            _buttonNewGame = GetComponentInChildren<ButtonNewGame>().GetComponent<Button>();
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                _buttonResumeGame = GetComponentInChildren<ButtonResumeGame>().GetComponent<Button>();
                _buttonResumeGame.onClick.AddListener(ResumeGame);
            }

            _buttonSettings = GetComponentInChildren<ButtonSettings>().GetComponent<Button>();
            _buttonQuit = GetComponentInChildren<ButtonQuit>().GetComponent<Button>();

            _canvas = GetComponent<Canvas>();

            _buttonNewGame.onClick.AddListener(NewGame);
            _buttonSettings.onClick.AddListener(OpenSettingsMenu);
            _buttonQuit.onClick.AddListener(QuitGame);
        }
        private void NewGame()
        {
            SceneManager.LoadScene("Level1");
            Time.timeScale = 1;
        }
        public void PauseGame()
        {
            Time.timeScale = 0;
            _canvas.enabled = true;
        }
        private void ResumeGame()
        {
            Time.timeScale = 1;
            _canvas.enabled = false;
        }

        private void OpenSettingsMenu()
        {
            _canvas.enabled = false;
        }

        private void QuitGame()
        {
            Application.Quit();
            Debug.Log("Quit");
        }
    }
}
