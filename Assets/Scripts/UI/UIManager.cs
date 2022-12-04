using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

namespace IbragimovAA.Arcanoid
{
    public class UIManager : MonoBehaviour
    {
        Button _buttonNewGame;
        Button _buttonSettings;
        Button _buttonQuit;
        private void Start()
        {
            _buttonNewGame = FindObjectOfType<Button>();          //GetComponentInChildren<Button>().Where(b => b.name == "");
            _buttonNewGame.onClick += Invoke("NewGame()");
        }
        public void NewGame()
        {
            SceneManager.LoadScene("Level1");
            Time.timeScale = 1;
        }
        public void PauseGame()
        {
            Time.timeScale = 0;
        }
    }
}
