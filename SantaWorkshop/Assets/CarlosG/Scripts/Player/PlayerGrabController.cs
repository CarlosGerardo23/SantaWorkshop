using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabController : MonoBehaviour
{
    [HideInInspector] public IInteractable objectInteractable;
    public bool IsGrabbing => objectInteractable != null;

    public bool IsGrabbingInteractable(IInteractable interactable)
    {
        return objectInteractable == interactable;
    }
}
