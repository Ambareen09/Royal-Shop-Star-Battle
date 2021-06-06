using UnityEngine;
public class BoardManager : MonoBehaviour
{
    public float[] angle;
    private GameObject _grass;
    private void OnMouseDown()
    {
        GetAllAdjacentTiles();
    }

    private void GetAdjacent(Vector2 castDir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, castDir);
        if (hit.collider != null)
        {

            Debug.DrawRay(transform.position, castDir * 0.6f, Color.magenta, 25f);
        }
    }

    private void GetRowColumn(Vector2 castDir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, castDir);
        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, castDir * 2f, Color.red, 25f);
        }
    }

    private void GetAllAdjacentTiles()
    {
        for (int i = 0; i < 8; i++)
        {
            Vector2 direction = new Vector2(Mathf.Cos(angle[i] * Mathf.Deg2Rad), Mathf.Sin(angle[i] * Mathf.Deg2Rad)).normalized;
            GetAdjacent(direction);
        }

        for (int i = 0; i < 8; i += 2)
        {
            Vector2 direction = new Vector2(Mathf.Cos(angle[i] * Mathf.Deg2Rad), Mathf.Sin(angle[i] * Mathf.Deg2Rad)).normalized;
            GetRowColumn(direction);
        }
    }

}
