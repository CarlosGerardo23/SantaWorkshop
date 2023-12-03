using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] toyParts;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnToyParts", 0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnToyParts()
    {
        Instantiate(toyParts[Random.Range(0, toyParts.Length)], transform.position, transform.rotation);
    }
}
