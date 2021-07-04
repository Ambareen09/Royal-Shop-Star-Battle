using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovesCounter : MonoBehaviour
{
    public Text moves;
    public int movesLeft;
    private void Start()
    {
        moves.text = movesLeft.ToString();
    }
    public void MovesLeft()
    {
        movesLeft--;
        moves.text = movesLeft.ToString();
    }
}
