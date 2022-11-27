using UnityEngine;

/* TODO

Собрать игровую сцену, которая содержит:
Камера игрока, перед которой расположен невидимая платформа для отбивания шарика; - СДЕЛАНО

Квадратный тоннель, стены и пол которого не разрушаются, за игроком располагаются невидимые ворота,
при пересечении с которыми мяч возвращается к игроку, а также уменьшается количество жизней; - СДЕЛАНО

Разрушаемые блоки, расположенные в центре тоннеля; - СДЕЛАНО

Мяч, который запускает первый игрок, и который отражается от стен, блоков и платформ игроков. - СДЕЛАНО

Добавить второго игрока, при этом в редакторе должно быть два окна Game, одно для первого игрока, второе для второго. - СДЕЛАНО

Управление платформой первого игрока обеспечивается клавишами WASD, второго - стрелками клавиатуры; - СДЕЛАНО

Добавить определение границ уровня - СДЕЛАНО

За вторым игроком вместо невидимой стены, тоже должны располагаться ворота. Количество жизней у игроков общее. - СДЕЛАНО

Платформы игроков должны обладать инерцией. Инерцию можно реализовать через физику или стандартной логикой перемещения. - СДЕЛАНО

При ударах о любую поверхность, шарик должен отражаться, согласно законам реальной физики. - СДЕЛАНО

Шарик может обладать компонентом физического тела, но он не должен перемещаться и отражаться с помощью физики. - СДЕЛАНО

Собрать несколько тоннелей на одной игровой сцене, реализовать переключение на новый тоннель (то есть, по сути, переход на новый уровень),
после уничтожения всех блоков в первом тоннеле. - сделать

Сделать случайный наклон блоков при старте уровня, для того, чтобы плоскость соприкосновения с блоками не была перпендикулярна тоннелю. - СДЕЛАНО

Добавить ускорение шарику при ударах по блокам: - СДЕЛАНО

При упускании шарика, его скорость возвращается к стандартной; - СДЕЛАНО

Скорость растет дискретно до определенного уровня, то есть не растет бесконечно. - СДЕЛАНО

Все настройки вынести в редактор, сопроводить комментариями для удобства работы геймдизайнеров с балансом игры. - СДЕЛАНО
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

        [SerializeField, Header("Количество жизней")]
        private int _lifes;
        [SerializeField, Header("Количество генерируемых блоков")]
        private int _blocksCount;
        [SerializeField, Header("Диапазон расстояния от центра генерируемых блоков ")]
        private int _randomRange;
        [SerializeField, Header("Диапазон поворота генерируемых блоков ")]
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
