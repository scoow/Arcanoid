using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace IbragimovAA.Arcanoid
{
    public class PlatformController : MonoBehaviour
    {
        [SerializeField, Header("Максимальная скорость платформы")]
        private float _maxSpeed;
        private float _speed;

        //расстояние от камеры до края платформы
        private readonly float _borderWidth = 1;

        private Vector2 _moveDirection;
        protected InputSystem _inputSystem;

        //разрешенные границы движения платформы
        private float _topBorder;
        private float _bottomBorder;
        private float _leftBorder;
        private float _rightBorder;

        private void Start()
        {
            _speed = _maxSpeed;
        }
        protected virtual void OnEnable()
        {
            _inputSystem = new InputSystem();
            _inputSystem.Enable();

            DefineLevelBorders();
        }

        protected void SetMovement(Vector2 direction)
        {
          
            _moveDirection += direction;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            CheckBordersCollision();

            transform.Translate(Time.deltaTime * _speed * _moveDirection);
        }

        private void CheckBordersCollision()
        {
            if (transform.position.y < _bottomBorder + _borderWidth || transform.position.y > _topBorder - _borderWidth)
                _moveDirection.y = -_moveDirection.y;

            if (transform.position.x < _leftBorder + _borderWidth || transform.position.x > _rightBorder - _borderWidth)
                _moveDirection.x = -_moveDirection.x;
        }

        private void OnDisable() => _inputSystem.Disable();

        //вычисление разрешенных границ движения платформы
        private void DefineLevelBorders()
        {
            List<CollisionTrigger> borders = FindObjectsOfType<CollisionTrigger>().ToList();
            _topBorder = borders.Max(t => t.transform.position.y);
            _bottomBorder = borders.Min(t => t.transform.position.y);
            _rightBorder = borders.Max(t => t.transform.position.x);
            _leftBorder = borders.Min(t => t.transform.position.x);
        }
    }
}