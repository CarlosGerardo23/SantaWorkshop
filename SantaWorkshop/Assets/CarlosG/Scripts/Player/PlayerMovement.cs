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
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private float _gravity;
    [SerializeField] private Transform[] _feets;
    [SerializeField] private float _feetDistance;
    private float _yVelocity = 0;
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
       // playerAnimator.transform.localPosition = new Vector3(transform.position.x, -1.558823f, transform.position.z);
        playerAnimator?.SetBool("isRunning", false);
        playerAnimator?.SetBool("isIdle", true);
        if (!IsFalling())
        {

            if (_currentMovement != Vector3.zero)
            {
                playerAnimator?.SetBool("isRunning", true);
                playerAnimator?.SetBool("isIdle", false);
                _characterController.Move(_currentMovement * Time.deltaTime * _characterMovementVelocity);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_currentMovement), _characterRotationVelocity);
            }
        }
    }
    private void OnMove(Vector2 movement)
    {
        _currentMovement = new Vector3(movement.x, 0, movement.y).normalized;
    }
    private bool IsFalling()
    {
        _yVelocity = 0;
        foreach (var feet in _feets)
        {
            Debug.Log("Feets Position: " + feet.position);
            Debug.Log("Ray Destination: " + (-feet.transform.up * _feetDistance));
            Vector3 rayDestination = feet.TransformDirection(-Vector3.up) * _feetDistance;
            Debug.DrawLine(feet.position, feet.position + rayDestination, Color.green);
            Ray ray = new Ray(feet.position, -feet.transform.up);
            if (!Physics.Raycast(ray, _feetDistance))
            {
                _yVelocity += _gravity * Time.deltaTime;
                rayDestination = feet.TransformDirection(-Vector3.up) * _feetDistance;
                Debug.DrawLine(feet.position, feet.position + rayDestination, Color.red);
                break;
            }
            else
                _yVelocity = 0;

            _characterController.Move(new Vector3(0, _yVelocity, 0));
        }

        return _yVelocity != 0;

    }
}
