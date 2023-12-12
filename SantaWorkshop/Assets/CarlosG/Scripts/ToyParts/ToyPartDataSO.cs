using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu( menuName = "Toy Part")]
public class ToyPartDataSO: ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _name;

    public bool isSet;
    public Sprite Icon => _icon;
    public string Name => _name;

}
