using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RulesCheck : MonoBehaviour
{
    public int[] blocks;
    public List<GameObject>[] FilledBlock = Enumerable.Range(0,5).Select((i)=>new List<GameObject>()).ToArray();

    public bool CheckBlock(int blockId)
    {
        return blocks[blockId] == 1;
    }

    public void IncreaseStore(int blockId)
    {
        blocks[blockId] += 1;
    }
    
    public void DecreaseStore(int blockId, GameObject shop)
    {
        FilledBlock[blockId].Remove(shop);
        blocks[blockId] -= 1;
    }
}
