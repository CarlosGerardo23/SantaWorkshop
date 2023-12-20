using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IInteractable : MonoBehaviour
{
   [Header("UI Animations")]
   [SerializeField] protected Animator _uiAnimator;
   public void Detected()
   {
      _uiAnimator.SetTrigger("Detect");
   }
   public void Lost()
   {
      _uiAnimator.SetTrigger("Lost");
   }
   public void MissInteraction()
   {
      _uiAnimator.SetTrigger("Miss");

   }
   public void CanInteract()
   {
      _uiAnimator.SetTrigger("Can");

   }
   public abstract void Interact(PlayerInteractionController player);

}
