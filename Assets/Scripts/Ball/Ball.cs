using UnityEngine;

namespace IbragimovAA.Arcanoid
{
    public class Ball : MonoBehaviour
    {
        [SerializeField]
        private float _startSpeed;
        [SerializeField]
        private float _maxSpeed;
        [SerializeField]
        private float _speedAddition;
        [SerializeField]
        private Vector3 _moveDirection = Vector3.up;

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
            _speed = _startSpeed;
            Debug.Log("Ball launched");//
        }
        public void ReturnToBallHolder(Transform handler)
        {
            _speed = 0;
            transform.position = handler.position;
        }

        public void IncreaseSpeed()
        {
            _speed += _speedAddition;
            if (_speed > _maxSpeed)
                _speed = _maxSpeed;
        }
        public void ReflectX()
        {
            _moveDirection.x = -_moveDirection.x;
        }
        public void ReflectY()
        {
            _moveDirection.y = -_moveDirection.y;
        }
        public void ReflectZ()
        {
            _moveDirection.z = -_moveDirection.z;
        }
        public void ComplexReflect(Transform other)
        {
            //_moveDirection.z = -_moveDirection.z;
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}