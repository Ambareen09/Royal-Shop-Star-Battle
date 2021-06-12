using System.Linq;
using UnityEngine;
public class RaycastToTiles : MonoBehaviour
{
    private readonly int[] _angle = {30,210,150, 340};
    protected RaycastHit2D[] GetRow()
    {
        var direction1 = new Vector2(Mathf.Cos(_angle[0] * Mathf.Deg2Rad), Mathf.Sin(_angle[0] * Mathf.Deg2Rad)).normalized; //UpperRow
        var direction2 = new Vector2(Mathf.Cos(_angle[1] * Mathf.Deg2Rad), Mathf.Sin(_angle[1] * Mathf.Deg2Rad)).normalized; //LowerRow
        var position = transform.position;
        Debug.DrawRay(position, direction2*2f, Color.magenta, 25f);
        Debug.DrawRay(position, direction1*2f, Color.magenta, 25f);
        // ReSharper disable once Unity.PreferNonAllocApi
        var hit1 = Physics2D.RaycastAll(position, direction1, 2f);
        // ReSharper disable once Unity.PreferNonAllocApi
        var hit2 = Physics2D.RaycastAll(position, direction2, 2f);

        for (var i = hit1.Length - 1; i >= 0; i--)
        {
            Debug.Log(hit1[i].collider.name + " " + hit1[i].collider.gameObject);
        }
        
        for (var i = hit2.Length - 1; i >= 0; i--)
        {
            Debug.Log(hit2[i].collider.name + " " + hit2[i].collider.gameObject);
        }
        return hit1.Concat(hit2).ToArray();
    }

    protected RaycastHit2D[] GetColumn()
    {
        var direction3 = new Vector2(Mathf.Cos(_angle[2] * Mathf.Deg2Rad), Mathf.Sin(_angle[2] * Mathf.Deg2Rad)).normalized; //UpperColumn
        var direction4 = new Vector2(Mathf.Cos(_angle[3] * Mathf.Deg2Rad), Mathf.Sin(_angle[3] * Mathf.Deg2Rad)).normalized; //LowerColumn
        var position = transform.position;
        Debug.DrawRay(position, direction4*2f, Color.red, 25f);
        Debug.DrawRay(position, direction3*2f, Color.red, 25f);
        // ReSharper disable once Unity.PreferNonAllocApi
        var hit1 = Physics2D.RaycastAll(position, direction3, 2f);
        // ReSharper disable once Unity.PreferNonAllocApi
        var hit2 = Physics2D.RaycastAll(position, direction4, 2f);

        for (var i = hit1.Length - 1; i >= 0; i--)
        {
            Debug.Log(hit1[i].collider.name + " " + hit1[i].collider.gameObject);
        }
        
        for (var i = hit2.Length - 1; i >= 0; i--)
        {
            Debug.Log(hit2[i].collider.name + " " + hit2[i].collider.gameObject);
        }
        return hit1.Concat(hit2).ToArray();
    }

    protected RaycastHit2D[] GetDiagonalAdjacent()
    {
        var position = transform.position;
        Debug.DrawRay(position, Vector2.up*0.4f, Color.black, 25f);
        Debug.DrawRay(position, Vector2.down*0.4f, Color.black, 25f);
        // ReSharper disable once Unity.PreferNonAllocApi
        var hit1 = Physics2D.RaycastAll(position, Vector2.up, 0.4f);
        // ReSharper disable once Unity.PreferNonAllocApi
        var hit2 = Physics2D.RaycastAll(position, Vector2.down, 0.6f);
        Debug.DrawRay(position, Vector2.left*0.6f, Color.black, 25f);
        Debug.DrawRay(position, Vector2.right*0.6f, Color.black, 25f);
        // ReSharper disable once Unity.PreferNonAllocApi
        var hit3 = Physics2D.RaycastAll(position, Vector2.left, 0.6f);
        // ReSharper disable once Unity.PreferNonAllocApi
        var hit4 = Physics2D.RaycastAll(position, Vector2.right, 0.6f);

        for (var i = hit1.Length - 1; i >= 0; i--)
        {
            Debug.Log(hit1[i].collider.name + " " + hit1[i].collider.gameObject);
        }
        
        for (var i = hit2.Length - 1; i >= 0; i--)
        {
            Debug.Log(hit2[i].collider.name + " " + hit2[i].collider.gameObject);
        }
        
        for (var i = hit3.Length - 1; i >= 0; i--)
        {
            Debug.Log(hit3[i].collider.name + " " + hit3[i].collider.gameObject);
        }
        for (var i = hit4.Length - 1; i >= 0; i--)
        {
            Debug.Log(hit4[i].collider.name + " " + hit4[i].collider.gameObject);
        }
        return hit1.Concat(hit2).Concat(hit3).Concat(hit4).ToArray();
    }
}
