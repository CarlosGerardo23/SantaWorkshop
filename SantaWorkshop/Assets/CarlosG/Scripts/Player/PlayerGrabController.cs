using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabController : MonoBehaviour
{
    [HideInInspector] public bool isGrabbing;
    [HideInInspector] public IInteractable objectInteractable;

    public bool IsGrabbingInteractable(IInteractable interactable)
    {
        return objectInteractable == interactable;
    }
}
