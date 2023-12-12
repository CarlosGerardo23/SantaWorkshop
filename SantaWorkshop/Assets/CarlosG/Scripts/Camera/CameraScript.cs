using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        CameraMovement();
    }

    private void CameraMovement()
    {
        transform.position = player.transform.position + offset;
    }
}
