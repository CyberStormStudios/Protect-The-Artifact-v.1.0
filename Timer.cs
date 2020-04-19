using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    float currentTime = 0;
    float startTime = 0;
    [SerializeField] private TextMeshProUGUI TimerText;

    void Start()
    {
        currentTime = startTime;  
    }


    void Update()
    {
        currentTime += 1 * Time.deltaTime;
        TimerText.text = currentTime.ToString("00:00");
    }
}
