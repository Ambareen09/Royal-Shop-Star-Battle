using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int nextScene;
    public void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }
    public void WintoNextLevel()
    {
        
        SceneManager.LoadScene(nextScene);
        if (nextScene > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextScene);
        }
    }
    
    public void BacktoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
