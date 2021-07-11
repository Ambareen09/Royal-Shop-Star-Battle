using System.Collections.Generic;
using System.Linq;
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
            _spriteRenderer.sprite = GetDiagonalAdjacent() && GetColumn().Count == 0 && GetRow().Count == 0 
                                     && _rulesCheck.CheckBlock(blockId) ? shop : incorrectShop;
        }
        else
        {
            var o = gameObject;
            o.tag = "Grass";
            o.layer = 9;
            _rulesCheck.DecreaseStore(blockId, o);
            var tbc = GetRow();
            tbc.AddRange(GetColumn());
            tbc.AddRange(_rulesCheck.CheckBlock(blockId) ? _rulesCheck.FilledBlock[blockId] : new List<GameObject>() { });
            foreach (var hit in tbc)
            {
                hit.GetComponent<SwitchTiles>().ChangeSprite();
                hit.GetComponent<SwitchTiles>().ChangeSprite();
            }

            _spriteRenderer.sprite = grass;
            
        }
    }
}
