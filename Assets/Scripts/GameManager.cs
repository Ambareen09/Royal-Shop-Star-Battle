using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private MovesCounter movesCounter;
    public int nextScene;
    public GameObject levelFailedPanel;
    public GameObject pausePanel;
    public GameObject[] gamebuttons;
    public Text lvlNo;
    public GameObject levelWonPanel;
    public void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        LevelNo();
    }
    private void Update()
    {
        if (Application.platform != RuntimePlatform.Android)
            return;

        if (Input.GetKeyDown(KeyCode.Escape)) 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
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

    public void LevelFailed()
    {
        Time.timeScale = 0f;
        levelFailedPanel.SetActive(true);
        movesCounter.moves.gameObject.SetActive(false);
        gamebuttons[0].SetActive(false);
        gamebuttons[1].SetActive(false);
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LevelNo()
    {
        lvlNo.text = "Level\n" + (nextScene - 1);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void LevelWon()
    {
        Time.timeScale = 0f;
        levelWonPanel.SetActive(true);
        movesCounter.moves.gameObject.SetActive(false);
        gamebuttons[0].SetActive(false);
        gamebuttons[1].SetActive(false);
    }
}

