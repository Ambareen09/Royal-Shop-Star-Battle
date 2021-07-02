using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{
    public Button[] levelButtons;

    public void Start()
    {
        var levelAt = PlayerPrefs.GetInt("levelAt", 1);

        for (var i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelAt)
                levelButtons[i].interactable = false;
        }
    }
}
