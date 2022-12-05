using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using TMPro;

namespace IbragimovAA.Arcanoid
{
    public class UIManager : MonoBehaviour
    {
        private List<Button> _buttons;
        private Button _buttonNewGame;
        private Button _buttonResumeGame;
        private Button _buttonSettings;
        private Button _buttonQuit;

        private Canvas _canvas;
        private List<TextMeshProUGUI> _hpTextList;
        private void Awake()
        {
            _buttons = GetComponentsInChildren<Button>().ToList();
            _buttonNewGame = _buttons.FirstOrDefault(b => b.gameObject.name == "ButtonNewGame");
            _buttonResumeGame = _buttons.FirstOrDefault(b => b.gameObject.name == "ButtonResumeGame");
            _buttonSettings = _buttons.FirstOrDefault(b => b.gameObject.name == "ButtonSettings");
            _buttonQuit = _buttons.FirstOrDefault(b => b.gameObject.name == "ButtonQuit");

            _hpTextList = FindObjectsOfType<TextMeshProUGUI>().Where(t => t.gameObject.name == "TextHPBar").ToList();

            _canvas = GetComponent<Canvas>();

            _buttonNewGame.onClick.AddListener(NewGame);
            _buttonResumeGame.onClick.AddListener(ResumeGame);
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
        public void RedrawHPBar(int hp)
        {
            foreach (TextMeshProUGUI text in _hpTextList)
            {
                text.text = hp.ToString();
            }
        }

        private void QuitGame()
        {
            Application.Quit();
            Debug.Log("Quit");
        }
    }
}
