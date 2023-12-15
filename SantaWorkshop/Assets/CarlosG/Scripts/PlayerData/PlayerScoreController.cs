using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScoreController : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _scoreText;
    [SerializeField] private string _giftTag;
    private int _currentScore = 0;
    private PlayerInteractionController _playerController;
    private void OnEnable()
    {
        _playerController = FindObjectOfType<PlayerInteractionController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_giftTag))
        {
            if (other.TryGetComponent(out GiftInteractable gift))
            {
                _currentScore++;
                _scoreText.text = _currentScore.ToString();
                gift.Interact(_playerController);
                Destroy(gift.gameObject);
            }

        }
    }
}
