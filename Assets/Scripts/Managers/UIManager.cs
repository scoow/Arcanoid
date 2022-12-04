using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace IbragimovAA.Arcanoid
{
    public class UIManager : MonoBehaviour
    {
        private List<Button> _buttons;
        private Button _buttonNewGame;
        private Button _buttonSettings;
        private Button _buttonQuit;

        private Canvas _canvas;
        private void Awake()
        {
            _buttons = GetComponentsInChildren<Button>().ToList();
            _buttonNewGame = _buttons.FirstOrDefault(b => b.gameObject.name == "ButtonNewGame");
            _buttonSettings = _buttons.FirstOrDefault(b => b.gameObject.name == "ButtonSettings");
            _buttonQuit = _buttons.FirstOrDefault(b => b.gameObject.name == "ButtonQuit");

            _canvas = GetComponent<Canvas>();

            _buttonNewGame.onClick.AddListener(NewGame);
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
        private void QuitGame()
        {
            Application.Quit();
            Debug.Log("Quit");
        }
    }
}
