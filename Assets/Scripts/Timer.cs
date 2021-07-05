using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining;
    public Text timeText;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        TimerRunning();
    }
    private void TimerRunning()
    {
        timeRemaining += Time.deltaTime;
        DisplayTime(timeRemaining);
    }

   private void DisplayTime(float timeToDisplay)
    {

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = $"{minutes:00} : {seconds:00}";
    }
}
