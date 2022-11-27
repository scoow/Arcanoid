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
            if (_moveDirection.magnitude > _maxSpeed)
                _moveDirection *= 0.8f;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(Time.deltaTime * _speed * _moveDirection);
            CheckBordersCollision();
        }

        private void CheckBordersCollision()
        {
            var position = transform.position;

            position.x = Mathf.Clamp(position.x,  _leftBorder + _borderWidth,  _rightBorder - _borderWidth);
            position.y = Mathf.Clamp(position.y, _bottomBorder + _borderWidth, _topBorder - _borderWidth);

            transform.position = position;
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