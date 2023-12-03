using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputReader;
    [SerializeField] private Transform _dropPoint;

    public Transform DropPoint => _dropPoint;
    private IInteractable _currentInteractable;
    // Start is called before the first frame update
    void Start()
    {
        _currentInteractable = null;
    }

    private void OnEnable()
    {
        _inputReader.OnInteractEvent += Interact;
    }
    private void OnDisable()
    {
        _inputReader.OnInteractEvent -= Interact;

    }
    private void Interact()
    {
        _currentInteractable?.Interact(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            Debug.Log($"Interactable detected {interactable.name}");
            _currentInteractable = interactable;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            if (_currentInteractable == interactable)
            {
                Debug.Log($"Interactable miss {interactable.name}");
                _currentInteractable = null;
            }
        }
    }
}
