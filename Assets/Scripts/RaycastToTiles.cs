using System.Linq;
using UnityEngine;
public class RaycastToTiles : MonoBehaviour
{
    private readonly int[] _angle = {30,205,150, 335};
    public LayerMask mask;
    public RaycastHit2D[] Hit4;
    public bool GetRow()
    {
        var direction1 = new Vector2(Mathf.Cos(_angle[0] * Mathf.Deg2Rad), Mathf.Sin(_angle[0] * Mathf.Deg2Rad)).normalized; //UpperRow
        var direction2 = new Vector2(Mathf.Cos(_angle[1] * Mathf.Deg2Rad), Mathf.Sin(_angle[1] * Mathf.Deg2Rad)).normalized; //LowerRow
        var position = transform.position;
        Debug.DrawRay(position, direction2*2f, Color.magenta, 2f);
        Debug.DrawRay(position, direction1*2f, Color.magenta, 2f);
        // ReSharper disable once Unity.PreferNonAllocApi
        var hit1 = Physics2D.RaycastAll(position, direction1, 2f,mask);
        // ReSharper disable once Unity.PreferNonAllocApi
        var hit2 = Physics2D.RaycastAll(position, direction2, 2f,mask);
        Hit4 = hit1.Concat(hit2).ToArray();
        if (Hit4 != null)
        {
            foreach (var t in Hit4)
            {
                Debug.Log(t.collider.gameObject);
                t.collider.gameObject.GetComponent<SpriteRenderer>().sprite = GetComponent<SwitchTiles>().incorrectShop;
                return false;
            }
        }
        //Hit4[0].collider.gameObject.GetComponent<SpriteRenderer>().sprite = GetComponent<SwitchTiles>().shop;
        return true;
    } 

    protected bool GetColumn()
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
        var hit = hit1.Concat(hit2).ToArray();
        foreach (var t in hit)
        {
            if (t.collider.gameObject.CompareTag("Shop"))
            {
                t.collider.gameObject.GetComponent<SpriteRenderer>().sprite = GetComponent<SwitchTiles>().incorrectShop;
                return false;
            }

            //  t.collider.gameObject.GetComponent<SpriteRenderer>().sprite = GetComponent<SwitchTiles>().shop;
        }
        return true;
    }

    protected bool GetDiagonalAdjacent()
    {
        var position = transform.position;
        Debug.DrawRay(position, Vector2.up*0.4f, Color.black, 25f);
        Debug.DrawRay(position, Vector2.down*0.4f, Color.black, 25f);
        // ReSharper disable once Unity.PreferNonAllocApi
        var hit1 = Physics2D.RaycastAll(position, Vector2.up, 0.4f);
        // ReSharper disable once Unity.PreferNonAllocApi
        var hit2 = Physics2D.RaycastAll(position, Vector2.down, 0.4f);
        Debug.DrawRay(position, Vector2.left*0.8f, Color.black, 25f);
        Debug.DrawRay(position, Vector2.right*0.8f, Color.black, 25f);
        // ReSharper disable once Unity.PreferNonAllocApi
        var hit3 = Physics2D.RaycastAll(position, Vector2.left, 0.8f);
        // ReSharper disable once Unity.PreferNonAllocApi
        var hit4 = Physics2D.RaycastAll(position, Vector2.right, 0.8f);
        
        var hit = hit1.Concat(hit2).Concat(hit3).Concat(hit4).ToArray();
        foreach (var t in hit)
        {
            if (t.collider.gameObject.CompareTag("Shop"))
            {
                t.collider.gameObject.GetComponent<SpriteRenderer>().sprite = GetComponent<SwitchTiles>().incorrectShop;
                return false;
            }
        }
        return true;
    }
}
