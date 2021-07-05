using System;
using System.Linq;
using UnityEngine;
public class SwitchTiles : RaycastToTiles
{
    
    public int blockId;
    public Sprite grass, shop, incorrectShop;
    private SpriteRenderer _spriteRenderer;
    private RulesCheck _rulesCheck;
    private void Start ()
    {
        _rulesCheck = GetComponentInParent<RulesCheck>();
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
            _rulesCheck.IncreaseStore(blockId);

            _rulesCheck.FilledBlock[blockId].Add(gameObject);
            //_spriteRenderer.sprite = (GetDiagonalAdjacent() && GetRow() && GetColumn() && GetComponentInParent<RulesCheck>().CheckBlock(blockId))? shop : incorrectShop;
            if (GetDiagonalAdjacent() && GetRow() && GetColumn())
            {
                if(_rulesCheck.CheckBlock(blockId))
                {
                    _rulesCheck.FilledBlock[blockId][0].GetComponent<SpriteRenderer>().sprite = shop;
                    _spriteRenderer.sprite = shop;
                } 
                else
                {
                    for (int i = 0; i < _rulesCheck.FilledBlock[blockId].Count; i++)
                    {
                        _rulesCheck.FilledBlock[blockId][i].GetComponent<SpriteRenderer>().sprite = incorrectShop;
                    }
                    
                }
                
            }
            _spriteRenderer.sprite = incorrectShop;

        } 
        else
        {
            gameObject.tag = "Grass";
            _spriteRenderer.sprite = grass;
            _rulesCheck.DecreaseStore(blockId);
        }
    }
}
