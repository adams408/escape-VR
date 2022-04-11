using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float startingTime;
    
    float currentTime = 0f;

    [SerializeField] TextMeshProUGUI timerText;

    private void Start()
    {
        currentTime = startingTime * 60f;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timerText.text = $"{(currentTime / 60f):0}:{(currentTime % 60f):0}";

        if (currentTime <= 0)
        {
            currentTime = 0;
            SceneManager.LoadScene(2);
        }
    }
}
