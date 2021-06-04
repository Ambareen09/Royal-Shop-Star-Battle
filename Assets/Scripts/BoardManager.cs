using UnityEngine;
public class BoardManager : MonoBehaviour
{
    private void OnMouseDown()
    {
        RayCastDetectUp();
        RayCastDetectDown();
        RayCastDetectLeft();
        RayCastDetectRight();
    }

    private void RayCastDetectUp()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up,20f);

        if (hit)
        {
            Debug.Log("We hit " + hit.collider.name);
            Debug.DrawRay(transform.position, Vector2.up, Color.red, 25f);
        }
    }

    private void RayCastDetectDown()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,20f);

        if (hit)
        {
            Debug.Log("We hit " + hit.collider.name);
            Debug.DrawRay(transform.position, Vector2.down, Color.blue, 25f);
        }
    }

    private void RayCastDetectLeft()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left,20f);

        if (hit)
        {
            Debug.Log("We hit " + hit.collider.name);
            Debug.DrawRay(transform.position, Vector2.left, Color.black, 25f);
        }
    }

    private void RayCastDetectRight()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right,20f);

        if (hit)
        {
            Debug.Log("We hit " + hit.collider.name);
            Debug.DrawRay(transform.position, Vector2.right, Color.magenta, 25f);
        }
    }
    
    
}
