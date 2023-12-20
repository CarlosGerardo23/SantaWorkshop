using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class RecipeToyPartData
{
    [SerializeField] private ToyPartDataSO _toyPartDataSO;
    public ToyPartDataSO Toy => _toyPartDataSO;
    public bool IsSet { get; set; }
    public string ToyName => _toyPartDataSO.Name;
}
