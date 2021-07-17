using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RulesCheck : MonoBehaviour
{
    public int[] blocks;
    public List<GameObject>[] FilledBlock = Enumerable.Range(0,5).Select((i)=>new List<GameObject>()).ToArray();
    public int counter = 0;
    public GameManager gameManager;
    
    public bool CheckBlock(int blockId)
    {
        return blocks[blockId] == 1;
    }

    public void IncreaseStore(int blockId, GameObject shop)
    {
        FilledBlock[blockId].Add(shop);
        blocks[blockId] += 1;
        counter++;
    }
    
    public void DecreaseStore(int blockId, GameObject shop)
    {
        FilledBlock[blockId].Remove(shop);
        blocks[blockId] -= 1;
        counter--;
    }

    public void CheckforGameWon()
    {
        GameObject[] correctShops = GameObject.FindGameObjectsWithTag("CorrectShop");
        if (correctShops.Length == blocks.Length)
        {
            Debug.Log("Game Won :)");
            gameManager.LevelWon();
            
        }
            
        
    }
}
