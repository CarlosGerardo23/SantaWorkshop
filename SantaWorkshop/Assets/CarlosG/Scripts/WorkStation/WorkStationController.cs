using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WorkStationController : IInteractable
{
    [SerializeField] private RecipeDataSO _recipe;
    private PlayerInteractionController _playerController;
    private bool _isReady;
    private void OnEnable()
    {
        _playerController = FindObjectOfType<PlayerInteractionController>();
    }
    private void OnDisable()
    {
        _recipe.ResetRecipe();
    }
    public override void Interact(PlayerInteractionController player)
    {
        if (_isReady)
        {
            _isReady = false;
            Debug.Log("Recipe is done");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isReady)
            return;
        if (other.TryGetComponent(out ToyInteractable toy))
        {
            if (_recipe.TryCheckItemRecipe(toy.ToyPartData))
            {
                toy.Interact(_playerController);
                Debug.Log($"Check succes {toy.ToyPartData.Name}");
                toy.gameObject.SetActive(false);
                if (_recipe.IsRecipeDone())
                {
                    _isReady = true;
                    Debug.Log("Is ready to create a toy");

                }
            }
        }
    }

}
