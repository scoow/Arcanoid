using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Ball : MonoBehaviour
{
    SerializeField]
    private float _startSpeed;
    [SerializeField]
    private float _maxSpeed;
    private float _speed = 0;

    CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        _characterController.Move(transform.TransformDirection(_speed * Time.deltaTime * Vector3.forward));
    }
    private void Launch()
    {
        _speed = _startSpeed;
    }

}
