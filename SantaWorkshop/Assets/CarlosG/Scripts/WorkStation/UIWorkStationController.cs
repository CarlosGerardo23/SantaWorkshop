using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWorkStationController : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image[] _icons;
    [SerializeField] private Color _checkSuccedColor;
    private Dictionary<string, UnityEngine.UI.Image> _currentRecipeDataUI;
    private void Start()
    {
        _currentRecipeDataUI = new Dictionary<string, UnityEngine.UI.Image>();
    }
    public void SetRecipe(RecipeDataSO recipe)
    {
        for (int i = 0; i < _icons.Length; i++)
        {
            if (recipe.TryGetToyByIndex(i, out ToyPartDataSO toy))
            {
                _icons[i].color = Color.white;
                _icons[i].sprite = toy.Icon;
                _currentRecipeDataUI.Add(toy.Name, _icons[i]);
            }
        }

    }

    public void UpdateRecipeUI(string toyName)
    {
        if (_currentRecipeDataUI.TryGetValue(toyName, out UnityEngine.UI.Image icon))
        {
            icon.color = _checkSuccedColor;
        }
    }

}
