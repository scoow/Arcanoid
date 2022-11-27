using UnityEngine;

namespace IbragimovAA.Arcanoid
{
    public class Ball : MonoBehaviour
    {
        [SerializeField, Header("Ќачальна€ скорость м€ча")]
        private float _startSpeed;
        [SerializeField, Header("ћаксимальна€ скорость м€ча")]
        private float _maxSpeed;
        [SerializeField, Header("Ўаг увеличени€ скорости м€ча")]
        private float _speedAddition;
        private Vector3 _moveDirection = new(-1, -1, -1);

        private float _speed = 0;

        private void Update()
        {
            Move();
        }
        private void Move()
        {
            transform.Translate(_speed * Time.deltaTime * _moveDirection);
        }
        public void Launch()
        {
            gameObject.SetActive(true);
            transform.SetParent(null);
            _speed = _startSpeed;
            _moveDirection = -_moveDirection;
        }
        public void ReturnToBallHolder(Transform handler)
        {
            _speed = 0;
            transform.position = handler.position;
            transform.SetParent(handler);
        }

        public void IncreaseSpeed()
        {
            _speed += _speedAddition;
            if (_speed > _maxSpeed)
                _speed = _maxSpeed;
        }

        private void OnCollisionEnter(Collision collision)
        {
            float speed = _moveDirection.magnitude;
            Vector3 physic = Vector3.Reflect(_moveDirection.normalized, collision.contacts[0].normal);
            _moveDirection = physic * Mathf.Max(speed, 0);

            Block block = collision.gameObject.GetComponent<Block>();
            if (block != null)
            {
                block.Disable();
                IncreaseSpeed();
            }
        }
    }
}