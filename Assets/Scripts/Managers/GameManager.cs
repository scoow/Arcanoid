using UnityEngine;

/* TODO
������� ������� �����, ������� ��������:
������ ������, ����� ������� ���������� ��������� ��������� ��� ��������� ������; - �������

���������� �������, ����� � ��� �������� �� �����������, �� ������� ������������� ��������� ������,
��� ����������� � �������� ��� ������������ � ������, � ����� ����������� ���������� ������; - �������� ����������� � ������, ������, ������� ��

����������� �����, ������������� � ������ �������; - �������

���, ������� ��������� ������ �����, � ������� ���������� �� ����, ������ � �������� �������. - ��������� ��������� �� ������

�������� ������� ������, ��� ���� � ��������� ������ ���� ��� ���� Game, ���� ��� ������� ������, ������ ��� �������. - �������

���������� ���������� ������� ������ �������������� ��������� WASD, ������� - ��������� ����������; - �������

�� ������ ������� ������ ��������� �����, ���� ������ ������������� ������. ���������� ������ � ������� �����. - �������

��������� ������� ������ �������� ��������. ������� ����� ����������� ����� ������ ��� ����������� ������� �����������. - �������

��� ������ � ����� �����������, ����� ������ ����������, �������� ������� �������� ������. - ��������� ��������� �� ������
����� ����� �������� ����������� ����������� ����, �� �� �� ������ ������������ � ���������� � ������� ������. - �������

������� ��������� �������� �� ����� ������� �����, ����������� ������������ �� ����� ������� (�� ����, �� ����, ������� �� ����� �������),
����� ����������� ���� ������ � ������ �������. - �������

������� ��������� ������ ������ ��� ������ ������, ��� ����, ����� ��������� ��������������� � ������� �� ���� ��������������� �������. - �������
�������� ��������� ������ ��� ������ �� ������: - �������

��� ��������� ������, ��� �������� ������������ � �����������; - �������

�������� ������ ��������� �� ������������� ������, �� ���� �� ������ ����������. - �������

��� ��������� ������� � ��������, ����������� ������������� ��� �������� ������ �������������� � �������� ����. - �������
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
