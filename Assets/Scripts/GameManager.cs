using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private MovesCounter movesCounter;
    public int nextScene;
    public GameObject gameOverpanel;
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

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverpanel.SetActive(true);
        movesCounter.moves.gameObject.SetActive(false);
    }
}
