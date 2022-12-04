using UnityEngine;

/* TODO
—обрать несколько тоннелей на одной игровой сцене, реализовать переключение на новый тоннель (то есть, по сути, переход на новый уровень),
после уничтожени€ всех блоков в первом тоннеле. - сделать
*/

namespace IbragimovAA.Arcanoid
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        private BlocksContainer _blocksContainer;
        private BlocksPool _blocksPool;

        private Transform _firstPlayerBallHolder;
        private Transform _secondPlayerBallHolder;
        private Ball _ball;

        [SerializeField, Header(" оличество жизней")]
        private int _lifes;
        [SerializeField, Header(" оличество генерируемых блоков")]
        private int _blocksCount;
        [SerializeField, Header("ƒиапазон рассто€ни€ от центра генерируемых блоков ")]
        private int _randomRange;
        [SerializeField, Header("ƒиапазон поворота генерируемых блоков ")]
        private int _randomAngle;

        private Players _currentPlayer;
        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            _firstPlayerBallHolder = FindObjectOfType<FirstPlayerBallHolder>().transform;
            _secondPlayerBallHolder = FindObjectOfType<SecondPlayerBallHolder>().transform;

            _ball = FindObjectOfType<Ball>();
            _ball.ReturnToBallHolder(_firstPlayerBallHolder);

            InitializeBlocksPool();

            _currentPlayer = Players.First;
        }

        private void InitializeBlocksPool()
        {
            _blocksContainer = FindObjectOfType<BlocksContainer>();
            _blocksPool = new(Resources.Load<Block>("Prefabs/Block"), _blocksContainer.transform, _blocksCount, _randomRange, _randomAngle);
        }

        public void LoseLife()
        {
            _lifes--;

            _currentPlayer = (Players)(((int)_currentPlayer + 1) % 2);

            Debug.Log($"Lifes left {_lifes}");

            switch (_currentPlayer)
            {
                case Players.First:
                    _ball.ReturnToBallHolder(_firstPlayerBallHolder);
                    break;
                case Players.Second:
                    _ball.ReturnToBallHolder(_secondPlayerBallHolder);
                    break;
            }

            if (_lifes < 1)              
                EndGame();
        }

        private void EndGame()
        {
            Debug.Log("Game Over");
            UnityEditor.EditorApplication.isPaused = true;
        }    

        public void StartGame()
        {
            _ball.Launch();
        }

        private enum Players
        {
            First,
            Second
        }

    }
}
