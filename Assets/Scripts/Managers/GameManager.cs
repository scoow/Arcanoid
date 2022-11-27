using UnityEngine;

/* TODO
Собрать игровую сцену, которая содержит:
Камера игрока, перед которой расположен невидимая платформа для отбивания шарика; - СДЕЛАНО

Квадратный тоннель, стены и пол которого не разрушаются, за игроком располагаются невидимые ворота,
при пересечении с которыми мяч возвращается к игроку, а также уменьшается количество жизней; - добавить возвращение к игроку, запуск, счётчик хп

Разрушаемые блоки, расположенные в центре тоннеля; - СДЕЛАНО

Мяч, который запускает первый игрок, и который отражается от стен, блоков и платформ игроков. - исправить отражение от блоков

Добавить второго игрока, при этом в редакторе должно быть два окна Game, одно для первого игрока, второе для второго. - сделать

Управление платформой первого игрока обеспечивается клавишами WASD, второго - стрелками клавиатуры; - сделать

За вторым игроком вместо невидимой стены, тоже должны располагаться ворота. Количество жизней у игроков общее. - сделать

Платформы игроков должны обладать инерцией. Инерцию можно реализовать через физику или стандартной логикой перемещения. - сделать

При ударах о любую поверхность, шарик должен отражаться, согласно законам реальной физики. - исправить отражение от блоков
Шарик может обладать компонентом физического тела, но он не должен перемещаться и отражаться с помощью физики. - СДЕЛАНО

Собрать несколько тоннелей на одной игровой сцене, реализовать переключение на новый тоннель (то есть, по сути, переход на новый уровень),
после уничтожения всех блоков в первом тоннеле. - сделать

Сделать случайный наклон блоков при старте уровня, для того, чтобы плоскость соприкосновения с блоками не была перпендикулярна тоннелю. - СДЕЛАНО
Добавить ускорение шарику при ударах по блокам: - сделать

При упускании шарика, его скорость возвращается к стандартной; - СДЕЛАНО

Скорость растет дискретно до определенного уровня, то есть не растет бесконечно. - СДЕЛАНО

Все настройки вынести в редактор, сопроводить комментариями для удобства работы геймдизайнеров с балансом игры. - сделать
*/

namespace IbragimovAA.Arcanoid
{
    public class GameManager : MonoBehaviour
    {
        private BlocksContainer _blocksContainer;
        private BlocksPool _blocksPool;

        private Transform _firstPlayerBallHolder;
        private Transform _secondPlayerBallHolder;
        private Ball _ball;

        [SerializeField]
        private int _lifes;
        [SerializeField]
        private int _blocksCount;

        void Start()
        {
            _firstPlayerBallHolder = FindObjectOfType<FirstPlayerBallHolder>().transform;
            _secondPlayerBallHolder = FindObjectOfType<SecondPlayerBallHolder>().transform;

            _ball = FindObjectOfType<Ball>();
            _ball.ReturnToBallHolder(_firstPlayerBallHolder);

            InitializeBlocksPool();
        }

        private void InitializeBlocksPool()
        {
            _blocksContainer = FindObjectOfType<BlocksContainer>();
            _blocksPool = new(Resources.Load<Block>("Prefabs/Block"), _blocksContainer.transform, _blocksCount);
        }

        public void LoseLife()//singleton?
        {
            _lifes--;
            _ball.ReturnToBallHolder(_firstPlayerBallHolder);

            if (_lifes < 0)
                EndGame();
        }

        private void EndGame()
        {
            UnityEditor.EditorApplication.isPaused = true;
        }    
    }
}
