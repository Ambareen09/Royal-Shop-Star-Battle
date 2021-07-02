using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{
    public Image locked;
    public Text unlocked;
    public Button[] levelButtons;
    private int _levelAt;

    public void Start()
    {
        _levelAt = PlayerPrefs.GetInt("levelAt", 1);
        UnlockLevel();
    }

    private void UnlockLevel()
    {
        for (var i = 0; i < levelButtons.Length; i++)
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
