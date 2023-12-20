using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGlobarInteractionDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))      
            interactable.Detected();
        

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))       
            interactable.Lost();
        
    }
}
