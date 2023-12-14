using UnityEngine;

public class ReindeerAlarmController : MonoBehaviour
{
	[SerializeField]
	public Light NoseLightSource;

    /// <summary>
    /// TODO: replace this with a sound reference and use it's audio.length instead
    /// </summary>
	[SerializeField]
	public float TEST_soundLength;

	private float secondsPassed = 0.0f;

    void Update()
    {
        secondsPassed += Time.deltaTime;

        float colorScale = Mathf.PingPong(secondsPassed, TEST_soundLength) / TEST_soundLength;
        NoseLightSource.color = Color.Lerp(Color.white, Color.red, colorScale);
    }
}
