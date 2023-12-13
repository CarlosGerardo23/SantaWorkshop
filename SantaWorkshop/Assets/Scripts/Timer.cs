using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField]private float remainingTime;
    
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            timerText.color = Color.red;
        }
      
        int minutes = Mathf.FloorToInt(remainingTime / 60F);    
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        
    }
}
