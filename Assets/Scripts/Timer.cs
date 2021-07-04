using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining;
    private bool _timerIsRunning;
    public Text timeText;

    private void Start()
    {
        // Starts the timer automatically
        _timerIsRunning = true;
    }

    void Update()
    {
        if (_timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                _timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = $"{minutes:00} : {seconds:00}";
    }
}
