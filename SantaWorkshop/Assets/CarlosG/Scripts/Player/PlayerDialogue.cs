using System.Collections;
using UnityEngine;

public class PlayerDialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Dialogue());
    }

    IEnumerator Dialogue()
    {
        dialogueBox.SetActive(true);

        // Wait for 2 seconds
        yield return new WaitForSeconds(3);

        // After waiting, deactivate the dialogue box
        dialogueBox.SetActive(false);
    }
}