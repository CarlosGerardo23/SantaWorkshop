using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Recipies Controller")]
public class RecipesControllerSO : ScriptableObject
{
    [SerializeField] private RecipeDataSO[] _recipesList;

    private List<RecipeDataSO> _recipesAvaliableList = new List<RecipeDataSO>();
    // Start is called before the first frame update
    void OnEnable()
    {
        Debug.Log("Set recipes controller");
        for (int i = 0; i < _recipesList.Length; i++)
            _recipesAvaliableList.Add(_recipesList[i]);
    }

    public RecipeDataSO GetRecipe()
    {
        RecipeDataSO recipe= _recipesAvaliableList[Random.Range(0,_recipesAvaliableList.Count)];
        _recipesAvaliableList.Remove(recipe);
        return  recipe;
    }

    public void RestRecipe(RecipeDataSO recipe)
    {
        if(!_recipesAvaliableList.Contains(recipe))
        {
            _recipesAvaliableList.Add(recipe);
        }
    }
}
