using System.Collections.Generic;
using UnityEngine;
public class BoardManager : MonoBehaviour
{
    
    public float[] angle;
    private void OnMouseDown()
    {
        GetAllAdjacentTiles();
        GetAllRowColumnTiles();
    }

    private GameObject GetAdjacent(Vector2 castDir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, castDir,0.6f);
        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, castDir * 0.6f, Color.magenta, 25f);
            return hit.collider.gameObject;
        }
        return null;
    }

    private GameObject GetRowColumn(Vector2 castDir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, castDir, 2f);
        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, castDir * 2f, Color.red, 25f);
            return hit.collider.gameObject;
        } 
        return null;
    }

    private List<GameObject> GetAllAdjacentTiles()
    {
        List<GameObject> adjacentTiles = new List<GameObject>();
        //if (SpriteRenderer.sprite == grass)
        //{
            for (int i = 0; i < 8; i++)
            {
                Vector2 direction = new Vector2(Mathf.Cos(angle[i] * Mathf.Deg2Rad), Mathf.Sin(angle[i] * Mathf.Deg2Rad)).normalized;
                GetAdjacent(direction);
                adjacentTiles.Add(GetAdjacent(direction));
            }
        //}
        foreach (var t in adjacentTiles)
        {
            Debug.Log(t);
        }
        return adjacentTiles;
    }
    
    private List<GameObject> GetAllRowColumnTiles()
    {
        List<GameObject> rowColumnTiles = new List<GameObject>();
        //if (SpriteRenderer.sprite == grass)
        //{
            for (int i = 0; i < 8; i += 2)
            {
                Vector2 direction = new Vector2(Mathf.Cos(angle[i] * Mathf.Deg2Rad), Mathf.Sin(angle[i] * Mathf.Deg2Rad)).normalized;
                GetRowColumn(direction);
                rowColumnTiles.Add(GetRowColumn(direction));

           // }
        }
        foreach (var t in rowColumnTiles)
        {
            Debug.Log(t);
        }
        return rowColumnTiles;
    }

}
