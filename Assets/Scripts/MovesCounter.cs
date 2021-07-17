using UnityEngine;
using UnityEngine.UI;

public class MovesCounter : MonoBehaviour
{
    public Text moves;
    public int movesLeft;
    [SerializeField] 
    private GameManager gameManager;
    private void Start()
    {
        moves.text = movesLeft.ToString();
    }
    public void MovesLeft()
    {
        movesLeft--;
        moves.text = movesLeft.ToString();
        if (movesLeft == -1)
        {
            gameManager.LevelFailed();
        }
    }
}
