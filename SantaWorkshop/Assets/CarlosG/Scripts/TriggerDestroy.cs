using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDestroy : MonoBehaviour
{
    [SerializeField] private Spawner deactivatedToyList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        deactivatedToyList.AvailableToys.Add(other.gameObject);
        //Destroy(other.gameObject);
    }
}
