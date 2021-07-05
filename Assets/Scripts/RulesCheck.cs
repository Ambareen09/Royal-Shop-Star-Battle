using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RulesCheck : MonoBehaviour
{
    public int[] blocks;
    public List<GameObject>[] FilledBlock = Enumerable.Range(0,5).Select((i)=>new List<GameObject>()).ToArray();

    public bool CheckBlock(int blockId)
    {
        if (blocks[blockId] == 1)
        {
            //FilledBlock[blockId][0].GetComponent<SpriteRenderer>().sprite = GetComponent<SwitchTiles>().shop;
            return true;
        }
        /* for (var i = 0 ; FilledBlock[blockId].Count > 0; i++)
         {
             FilledBlock[blockId][i].gameObject.GetComponent<SpriteRenderer>().sprite = GetComponent<SwitchTiles>().incorrectShop;
         } */
        
        return false;
    }

    public void IncreaseStore(int blockId)
    {
        blocks[blockId] += 1;
    }
    
    public void DecreaseStore(int blockId)
    {
        blocks[blockId] -= 1;
    }
}
