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

	private void FixedUpdate()
	{
		/*if (Mathf.Abs(rotationAngle) > 0.0f)
		{
			playerCamera.transform.RotateAround(player.transform.position, Vector3.up, Time.deltaTime * rotationAngle * rotateSpeed);
		}*/

		transform.position = player.transform.position + offset;
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
		if (mouseScroll.y > 0)
		{
			zoomScale -= Time.deltaTime * zoomSpeed;
			if (zoomScale < zoomMin)
				zoomScale = zoomMin;
		}
		else if (mouseScroll.y < 0)
		{
			zoomScale += Time.deltaTime * zoomSpeed;
			if (zoomScale > zoomMax)
				zoomScale = zoomMax;
		}

		//transform.position = new Vector3(transform.position.x, offset.y * zoomScale, offset.z * zoomScale);
	}
}
