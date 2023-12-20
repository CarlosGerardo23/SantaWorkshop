using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookAtCamera : MonoBehaviour
{
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera= Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
         // Obtener la posición de la cámara en el mismo plano que el objeto (sin afectar el eje Y)
            Vector3 targetPosition = new Vector3(_camera.transform.position.x, _camera.transform.position.y, _camera.transform.position.z);

            // Obtener la dirección hacia la cámara sin afectar el eje Y
            Vector3 lookAtDirection = targetPosition - transform.position;

            // Rotar el objeto para que mire hacia la cámara en los ejes X y Z, pero no en el eje Y
            transform.rotation = Quaternion.LookRotation(lookAtDirection, Vector3.up);
    }
}
