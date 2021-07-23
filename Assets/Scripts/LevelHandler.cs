using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{
    public Button[] levelButtons;
    private int _levelAt;

    public void Start()
    {
        
       // _levelAt = PlayerPrefs.GetInt("levelAt", 1);
        _levelAt = SaveSystem.LevelAt;
        LockUnlockLevel();
    }

    private void LockUnlockLevel()
    {
        for (var i = 1; i < levelButtons.Length; i++)
        {
            if (i + 1 > _levelAt)
            {
                levelButtons[i].interactable = false;
            }
            if (levelButtons[i].interactable)
            {
                gameObject.transform.GetChild(0).GetChild(i).GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(0).GetChild(i).GetChild(1).gameObject.SetActive(false);
            }
        }
        
    }
    
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
