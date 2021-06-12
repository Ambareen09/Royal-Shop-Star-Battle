using UnityEngine;

public class SwitchTiles : RaycastToTiles
{
    public Sprite grass, shop;
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
            _spriteRenderer.sprite = shop;
            GetRow();
            GetColumn();
            GetDiagonalAdjacent();
        } else
        {
            _spriteRenderer.sprite = grass;
        }
    }
}
