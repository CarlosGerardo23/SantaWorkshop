using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWorkStationController : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image[] _icons;
    [SerializeField] private Color _checkSuccedColor;
    private Dictionary<string, UnityEngine.UI.Image> _currentRecipeDataUI;
    [SerializeField] private Image giftImage;
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

                if (!_currentRecipeDataUI.ContainsKey($"{toy.Name} {i}"))
                {
                    _currentRecipeDataUI.Add($"{toy.Name} {i}", _icons[i]);
                }
            }
        }

        giftImage.sprite = recipe._giftIcon;
    }

    public void UpdateRecipeUI(string toyName)
    {
        for (int i = 0; i < _icons.Length; i++)
        {
            if (_currentRecipeDataUI.TryGetValue($"{toyName} {i}", out UnityEngine.UI.Image icon))
            {
                if (icon.color == _checkSuccedColor)
                    continue;
                icon.color = _checkSuccedColor;
                return;
            }
        }
    }

}
