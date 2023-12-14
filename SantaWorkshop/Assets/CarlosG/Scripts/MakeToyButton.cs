using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeToyButton : MonoBehaviour
{
    [SerializeField] private GameObject machineDoor;
    [SerializeField] private float machineDoorOpenSpeed = 1.0f;
    
    private bool playerCollided;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        

        while (Input.GetKeyDown(KeyCode.E) && playerCollided == true)
        {
            if (machineDoor.transform.position.y != 11.5)
            {

                machineDoor.transform.Translate(Vector3.up * machineDoorOpenSpeed * Time.deltaTime);
                Debug.Log("Interacted True");

            }

        }
        /*else if (Input.GetKeyUp(KeyCode.E))
        {
            Debug.Log("Interacted False");
            
        }*/
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Debug.Log("Something Collided with Switch");

            playerCollided = true;

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            playerCollided = false;

        }
    }
}
