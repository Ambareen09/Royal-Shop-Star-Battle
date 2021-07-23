using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class RulesCheck : MonoBehaviour
{
    public int[] blocks;
    public List<GameObject>[] FilledBlock = Enumerable.Range(0,5).Select((i)=>new List<GameObject>()).ToArray();
    public GameManager gameManager;
    
    public bool CheckBlock(int blockId)
    {
        return blocks[blockId] == 1;
    }

    public void IncreaseStore(int blockId, GameObject shop)
    {
        FilledBlock[blockId].Add(shop);
        blocks[blockId] += 1;
    }
    
    public void DecreaseStore(int blockId, GameObject shop)
    {
        FilledBlock[blockId].Remove(shop);
        blocks[blockId] -= 1;
    }

    public async void CheckforGameWon()
    {
        var correctShops = GameObject.FindGameObjectsWithTag("CorrectShop");
        if (correctShops.Length != blocks.Length)
            return;

        Debug.Log("Game Won :)");
        await Task.Delay(1000);
        gameManager.LevelWon();
        /*else
        {
            Debug.Log("Keep Trying :(");
            gameManager.TryAgain();
        } */
    }
}
