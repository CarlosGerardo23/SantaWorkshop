using UnityEngine;
using static UnityEngine.GridBrushBase;

public class CameraScript : MonoBehaviour
{

    [SerializeField] private GameObject player;
	[SerializeField] private InputReaderSO inputReader;
	private Camera playerCamera;

	[SerializeField] private Vector3 offset = new Vector3(0, 10, -10);
	[SerializeField] private float zoomMin = 0.5f;
	[SerializeField] private float zoomMax = 5.0f;
	[SerializeField] private float zoomSpeed = 1.0f;
	private float zoomScale = 1.0f;

	[SerializeField] private float rotateSpeed = 90.0f;
	private float rotationAngle = 0.0f;

	void OnEnable()
	{
		playerCamera = GetComponent<Camera>();
		inputReader.OnRotateEvent += RotateCamera;
		inputReader.OnZoomEvent += ZoomCamera;
	}

	void OnDisable()
	{
		inputReader.OnRotateEvent -= RotateCamera;
		inputReader.OnZoomEvent -= ZoomCamera;
	}

	private void Update()
	{
		// Update the camera's position based on player's position and adjusted offset
		transform.position = player.transform.position + offset * zoomScale;

		// Ensure the camera is always looking at the player
		transform.LookAt(player.transform);
	}


	void RotateCamera(float rotationDirection)
    {
		rotationAngle = Time.deltaTime * rotationDirection * rotateSpeed;
	}

	/// <summary>
	/// TODO: implement mouse wheel zoom
	/// </summary>
	/// <param name="mouseScroll"></param>
	void ZoomCamera(Vector2 mouseScroll)
	{
		float zoomDelta = mouseScroll.y * Time.deltaTime * zoomSpeed;

		zoomScale += zoomDelta;
		zoomScale = Mathf.Clamp(zoomScale, zoomMin, zoomMax);

		// Adjust the camera's position based on zoom
		transform.position = new Vector3(transform.position.x, offset.y * zoomScale, offset.z * zoomScale);
	}
}
