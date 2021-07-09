using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
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
}
