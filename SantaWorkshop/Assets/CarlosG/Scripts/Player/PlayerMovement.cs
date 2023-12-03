using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputReader;
    [SerializeField] private float _characterMovementVelocity = 2f;
    [SerializeField] private float _characterRotationVelocity = 0.1f;
    private CharacterController _characterController;
    private Vector3 _currentMovement;
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    private void OnEnable()
    {
        _inputReader.EnablePlayerActions();
        _inputReader.MoveEvent += OnMove;
    }
    private void OnDisable()
    {
        _inputReader.MoveEvent -= OnMove;
    }
    private void Update()
    {
        if (_currentMovement != Vector3.zero)
        {
            _characterController.Move(_currentMovement * Time.deltaTime * _characterMovementVelocity);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_currentMovement), _characterRotationVelocity);
        }
    }
    private void OnMove(Vector2 movement)
    {
        _currentMovement = new Vector3(movement.x, 0, movement.y).normalized;
    }
}
