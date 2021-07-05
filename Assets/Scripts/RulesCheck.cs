using System.Collections.Generic;
using UnityEngine;

public class RulesCheck : MonoBehaviour
{
    public int[] blocks;
    public List<GameObject>[] FilledBlock = new List<GameObject>[5];

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
