using UnityEngine;
using UnityEngine.UI;
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
            _spriteRenderer.sprite = (GetDiagonalAdjacent() && GetRow() && GetColumn() && GetComponentInParent<RulesCheck>().CheckBlock(blockId))? shop : incorrectShop;
        } 
        else
        {
            gameObject.tag = "Grass";
            _spriteRenderer.sprite = grass;
            GetComponentInParent<RulesCheck>().DecreaseStore(blockId);
        }
    }

    
}
