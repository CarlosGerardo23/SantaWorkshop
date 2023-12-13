using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] toyParts;
    [SerializeField] private float spawnRate = 1.0f;
                     public List<GameObject> AvailableToys = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
        //InvokeRepeating("SpawnToyParts", 0, 3);
        StartCoroutine(SpawnToyParts());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnToyParts()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);

            if (AvailableToys.Count > 0)
            {
                GameObject temp = AvailableToys[Random.Range(0, AvailableToys.Count)];
                temp.SetActive(true);
                temp.transform.position = transform.position;
                temp.transform.rotation = transform.rotation;
                AvailableToys.Remove(temp);
            }
            else
            {
                Instantiate(toyParts[Random.Range(0, toyParts.Length)], transform.position, transform.rotation);
            }
        }

    }

    /*private void SpawnToyParts()
    {
        Instantiate(toyParts[Random.Range(0, toyParts.Length)], transform.position, transform.rotation);
    }*/
}
