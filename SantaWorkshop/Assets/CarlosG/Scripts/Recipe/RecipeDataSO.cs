using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Recipe")]
public class RecipeDataSO : ScriptableObject
{
    [SerializeField] private RecipeToyPartData[] _toyPartsList;
    [SerializeField] private GameObject _prefabToy;
    [SerializeField] public Sprite _giftIcon;

    private void OnEnable()
    {
        for (int i = 0; i < _toyPartsList.Length; i++)
        {
            _toyPartsList[i].IsSet=false;
        }
    }
    public bool IsRecipeDone()
    {
        for (int i = 0; i < _toyPartsList.Length; i++)
        {
            if (!_toyPartsList[i].IsSet)
                return false;
        }
        return true;
    }
    public void ResetRecipe()
    {
        for (int i = 0; i < _toyPartsList.Length; i++)
            _toyPartsList[i].IsSet = false;
    }

    public bool TryCheckItemRecipe(ToyPartDataSO data)
    {
        for (int i = 0; i < _toyPartsList.Length; i++)
        {
            if (_toyPartsList[i].IsSet)
                continue;
            if (data.Name == _toyPartsList[i].ToyName)
            {
                _toyPartsList[i].IsSet = true;
                return true;
            }
        }
        return false;
    }

    public GameObject CreateToy()
    {
        return Instantiate(_prefabToy);
    }
    public bool TryGetToyByIndex(int index, out ToyPartDataSO toy)
    {
        toy = null;
        try
        {
            toy = _toyPartsList[index].Toy;
            return true;
        }
        catch
        {
            return false;
        }
    }
}
