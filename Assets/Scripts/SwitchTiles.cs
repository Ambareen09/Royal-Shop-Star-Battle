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
            gameObject.tag = "Shop";
            gameObject.layer = 8;
            _movesCounter.MovesLeft();
            _rulesCheck.IncreaseStore(blockId);
            _rulesCheck.FilledBlock[blockId].Add(gameObject);

            if( GetDiagonalAdjacent() && GetRow() && GetColumn() && _rulesCheck.CheckBlock(blockId))
            {
                _spriteRenderer.sprite = shop;
            } 
                
            else if(!(GetDiagonalAdjacent() || GetRow() || GetColumn()))
            {
                    
                _spriteRenderer.sprite = incorrectShop;
            }
                
            else if (!_rulesCheck.CheckBlock(blockId))
            {
                for (int i = 0; i < _rulesCheck.FilledBlock[blockId].Count; i++)
                {
                    _rulesCheck.FilledBlock[blockId][i].GetComponent<SpriteRenderer>().sprite = incorrectShop;
                }  
                _spriteRenderer.sprite = incorrectShop;
            }
            else if (!(GetDiagonalAdjacent() && GetRow() && GetColumn() && _rulesCheck.CheckBlock(blockId)))
            {
                _spriteRenderer.sprite = incorrectShop;
            }

        } 
        else
        {
            gameObject.tag = "Grass";
            gameObject.layer = 9;
            // ReSharper disable once Unity.InefficientPropertyAccess
            _rulesCheck.FilledBlock[blockId].Remove(gameObject);
             if (_rulesCheck.FilledBlock[blockId].Count == 1)
                 _rulesCheck.FilledBlock[blockId][0].GetComponent<SpriteRenderer>().sprite = shop;
             _spriteRenderer.sprite = grass;
            _rulesCheck.DecreaseStore(blockId);
            
        }
    }
}
