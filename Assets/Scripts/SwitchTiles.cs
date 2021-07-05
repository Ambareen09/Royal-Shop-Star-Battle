using System;
using System.Linq;
using UnityEngine;
public class SwitchTiles : RaycastToTiles
{
    
    public int blockId;
    public Sprite grass, shop, incorrectShop;
    private SpriteRenderer _spriteRenderer;
    private void Start ()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); 
        if (_spriteRenderer.sprite == null)
            _spriteRenderer.sprite = grass;
    }

    private void OnMouseDown()
    {
        ChangeSprite();
    }

    private void ChangeSprite()
    {
        if (_spriteRenderer.sprite == grass)
        {
            GetComponentInParent<MovesCounter>().MovesLeft();
            gameObject.tag = "Shop";
            GetComponentInParent<RulesCheck>().IncreaseStore(blockId);
            GetComponentInParent<RulesCheck>().FilledBlock[blockId].Append(gameObject);
            Debug.Log(GetComponentInParent<RulesCheck>().FilledBlock[blockId]);
            Debug.Log(gameObject);
            //_spriteRenderer.sprite = (GetDiagonalAdjacent() && GetRow() && GetColumn() && GetComponentInParent<RulesCheck>().CheckBlock(blockId))? shop : incorrectShop;
            if (GetDiagonalAdjacent() && GetRow() && GetColumn())
            {
                if(GetComponentInParent<RulesCheck>().CheckBlock(blockId))
                {
                    GetComponentInParent<RulesCheck>().FilledBlock[blockId][0].GetComponent<SpriteRenderer>().sprite = shop;
                    _spriteRenderer.sprite = shop;
                } 
                else
                {
                    for (int i = 0; i < GetComponentInParent<RulesCheck>().FilledBlock[blockId].Count; i++)
                    {
                        GetComponentInParent<RulesCheck>().FilledBlock[blockId][i].GetComponent<SpriteRenderer>().sprite = incorrectShop;
                    }
                    
                }
                
            }
            _spriteRenderer.sprite = incorrectShop;

        } 
        else
        {
            gameObject.tag = "Grass";
            _spriteRenderer.sprite = grass;
            GetComponentInParent<RulesCheck>().DecreaseStore(blockId);
        }
    }
}
