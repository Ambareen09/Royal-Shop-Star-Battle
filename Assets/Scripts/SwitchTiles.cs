using UnityEngine;
public class SwitchTiles : RaycastToTiles
{
    
    public int blockId;
    public Sprite grass, shop, incorrectShop;
    private SpriteRenderer _spriteRenderer;
    private RulesCheck _rulesCheck;
    private MovesCounter _movesCounter;
    private RaycastToTiles _raycast;
    private void Start ()
    {
        _movesCounter = GetComponentInParent<MovesCounter>();
        _rulesCheck = GetComponentInParent<RulesCheck>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _raycast = GetComponent<RaycastToTiles>();
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
            var o = gameObject;
            o.tag = "Shop";
            o.layer = 8;
            _movesCounter.MovesLeft();
            _rulesCheck.IncreaseStore(blockId);
            _rulesCheck.FilledBlock[blockId].Add(gameObject);
            _spriteRenderer.sprite = GetDiagonalAdjacent() && GetColumn() && GetRow() 
                                     && _rulesCheck.CheckBlock(blockId) ? shop : incorrectShop;
        }
        else
        {
            var o = gameObject;
            o.tag = "Grass";
            o.layer = 9;
            // ReSharper disable once Unity.InefficientPropertyAccess
            _rulesCheck.FilledBlock[blockId].Remove(o);
             if (_rulesCheck.FilledBlock[blockId].Count == 1)
                 _rulesCheck.FilledBlock[blockId][0].GetComponent<SpriteRenderer>().sprite = shop;
             _spriteRenderer.sprite = grass;
            _rulesCheck.DecreaseStore(blockId);
            
        }
    }
}
