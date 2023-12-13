using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public enum BeltDirection
    {
        None,
        Up,
        Down,
        Left,
        Right,
    }

    [SerializeField]
    public BeltDirection ConveyorBeltDirection = BeltDirection.None;

	[SerializeField]
	private float TEST_Speed = 1.0f;
	[SerializeField]
	private float TEST_Speed_Material = 1.0f;

	private void Update()
	{
		var beltRenderer = gameObject.GetComponent<Renderer>();
		if (beltRenderer == null)
		{
			return;
		}

		// move the tex coords to simulate belt scrolling
		// TODO: remove when animation exists
		Vector2 newOffset = beltRenderer.material.mainTextureOffset;
		float offsetMagnitude = TEST_Speed_Material * Time.deltaTime;

		switch (ConveyorBeltDirection)
		{
			case BeltDirection.Left:
				newOffset.x -= offsetMagnitude;
				break;
			case BeltDirection.Right:
				newOffset.x += offsetMagnitude;
				break;
			case BeltDirection.Up:
				newOffset.y += offsetMagnitude;
				break;
			case BeltDirection.Down:
				newOffset.y -= offsetMagnitude;
				break;
		}

		beltRenderer.material.mainTextureOffset = newOffset;
	}

	/// <summary>
	/// Moves collided object across the belt.
	/// </summary>
	private void OnCollisionStay(Collision objectOnBelt)
    {
        Vector3 newPos = objectOnBelt.collider.transform.position;
        float forceMagnitude = TEST_Speed * Time.deltaTime;

		switch (ConveyorBeltDirection)
        {
            case BeltDirection.Left:
				newPos.x -= forceMagnitude;
                break; 
            case BeltDirection.Right:
				newPos.x += forceMagnitude;
				break; 
            case BeltDirection.Up:
				newPos.z += forceMagnitude;
				break; 
            case BeltDirection.Down:
				newPos.z -= forceMagnitude;
				break;
        }

		objectOnBelt.collider.transform.position = newPos;
    }

 
}
