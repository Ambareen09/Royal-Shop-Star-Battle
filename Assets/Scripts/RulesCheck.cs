using UnityEngine;
using UnityEngine.UI;

public class RulesCheck : MonoBehaviour
{
    public int[] blocks;
    public bool CheckBlock(int blockId)
    {
        return blocks[blockId] == 1;
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
