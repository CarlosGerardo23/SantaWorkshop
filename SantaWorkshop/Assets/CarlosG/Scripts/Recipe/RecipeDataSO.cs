using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Recipe")]
public class RecipeDataSO : ScriptableObject
{
    [SerializeField] private ToyPartDataSO[] _toyPartsList;
    [SerializeField] private GameObject _prefabToy;
    [SerializeField] private Sprite _giftIcon;
    public bool IsRecipeDone()
    {
        for (int i = 0; i < _toyPartsList.Length; i++)
        {
            if (!_toyPartsList[i].isSet)
                return false;
        }
        return true;
    }
    public void ResetRecipe()
    {
        for (int i = 0; i < _toyPartsList.Length; i++)
            _toyPartsList[i].isSet = false;
    }

    public bool TryCheckItemRecipe(ToyPartDataSO data)
    {
        for (int i = 0; i < _toyPartsList.Length; i++)
        {
            if (data.Name == _toyPartsList[i].Name)
            {
                data.isSet = true;
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
            toy = _toyPartsList[index];
            return true;
        }
        catch
        {
            return false;
        }
    }
}
