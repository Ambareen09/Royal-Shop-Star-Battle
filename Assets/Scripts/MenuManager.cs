using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text coins;
    private void Start()
    {
        SaveSystem.LoadPlayer();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        coins.text = SaveSystem.Coins.ToString();
    }
    private void Update()
    {
        if (Application.platform != RuntimePlatform.Android)
            return;

        if (Input.GetKeyDown(KeyCode.Escape)) 
            Application.Quit();
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitApplication()
    {
        Application.Quit();
        Debug.Log("App exited");
    }

    public void DisplayCoins()
    {
        //coins.text = PlayerPrefs.GetInt("coins").ToString();
    }
    
}
