using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TimeUntilChristmasCountdown : MonoBehaviour
{

[SerializeField] public float totalTime = 300f;
[SerializeField] private TextMeshProUGUI countdownTimerText;
[SerializeField] private GameObject outOfTime;
    public int minutes;
    public int seconds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        // Ensure time doesn't go below zero
        totalTime = Mathf.Max(0, totalTime - Time.deltaTime);

        // Calculate minutes and seconds
        minutes = Mathf.FloorToInt(totalTime / 60);
        seconds = Mathf.FloorToInt(totalTime % 60);

        // Display the countdown
        countdownTimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Optionally: You can trigger an event or perform an action when the countdown reaches zero.
        if (totalTime <= 0)
        {
            totalTime = 0;
            outOfTime.SetActive(true);
            Debug.Log("Time has run out!");
        }
        
        if (totalTime <= 10)
        {
            countdownTimerText.color = Color.red;
        }
    }
}
