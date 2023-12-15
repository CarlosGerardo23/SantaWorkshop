using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WorkStationController : IInteractable
{
    [SerializeField] private RecipeDataSO[] _recipe;
    [SerializeField] private Transform _toysParent;
    [SerializeField] private string _giftTag;
    private PlayerInteractionController _playerController;
    private UIWorkStationController _uiWorkStation;
    private bool _isReady;
    private RecipeDataSO _currentRecipe;

    private void Start()
    {
        _uiWorkStation = GetComponentInChildren<UIWorkStationController>();
        _currentRecipe = _recipe[Random.Range(0, _recipe.Length)];
        _uiWorkStation.SetRecipe(_currentRecipe);
    }
    private void OnEnable()
    {
        _playerController = FindObjectOfType<PlayerInteractionController>();
    }
    private void OnDisable()
    {
        _currentRecipe.ResetRecipe();
    }
    public override void Interact(PlayerInteractionController player)
    {
        if (_currentRecipe.IsRecipeDone())
        {
            _isReady = false;
            GameObject toy = _currentRecipe.CreateToy();
            toy.transform.localScale = Vector3.one;
            toy.transform.SetParent(_toysParent);
            toy.transform.localPosition = Vector3.zero;

            Debug.Log("Recipe is done");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isReady|| other.CompareTag(_giftTag))
            return;
        if (other.TryGetComponent(out ToyInteractable toy))
        {
            if (_currentRecipe.TryCheckItemRecipe(toy.ToyPartData))
            {
                _uiWorkStation.UpdateRecipeUI(toy.ToyPartData.Name);
                toy.Interact(_playerController);
                Debug.Log($"Check succes {toy.ToyPartData.Name}");
                toy.gameObject.SetActive(false);
                Destroy(toy, 0.3f);
                if (_currentRecipe.IsRecipeDone())
                {
                    _isReady = true;
                    Debug.Log("Is ready to create a toy");

                }
            }
        }
    }

}
