using bragimovAA.Arcanoid;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace IbragimovAA.Arcanoid
{
    public class PlatformController : MonoBehaviour
    {
        private Vector3 _moveDirection;
        protected InputSystem _inputSystem;

        private float _topBorder;
        private float _bottomBorder;
        private float _leftBorder;
        private float _rightBorder;

        private float _borderWidth = 1;

        protected virtual void OnEnable()
        {
            _inputSystem = new InputSystem();
            _inputSystem.Enable();

            DefineLevelBorders();
        }

        protected void SetMovement(Vector2 direction)
        {
            _moveDirection.x += direction.x;
            _moveDirection.y += direction.y;
        }
        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (transform.position.y < _bottomBorder + _borderWidth || transform.position.y > _topBorder - _borderWidth)
                _moveDirection.y = -_moveDirection.y;

            if (transform.position.x < _leftBorder + _borderWidth || transform.position.x > _rightBorder - _borderWidth)
                _moveDirection.x = -_moveDirection.x;

            transform.Translate(Time.deltaTime * _moveDirection);
        }

        private void OnDisable() => _inputSystem.Disable();

        private void DefineLevelBorders()
        {
            List<CollisionTrigger> borders = new List<CollisionTrigger>();
            borders = FindObjectsOfType<CollisionTrigger>().ToList();
            _topBorder = borders.Max(t => t.transform.position.y);
            _bottomBorder = borders.Min(t => t.transform.position.y);
            _rightBorder = borders.Max(t => t.transform.position.x);
            _leftBorder = borders.Min(t => t.transform.position.x);
        }
    }
}