using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScoreController : MonoBehaviour
{
    [SerializeField] private string _giftTag;
    private int _currentScore = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_giftTag))
        {

        }
    }
}
