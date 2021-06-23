using UnityEngine;
public class SwitchTiles : RaycastToTiles
{
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
            gameObject.tag = "Shop";
            _spriteRenderer.sprite = (GetDiagonalAdjacent() && GetRow() && GetColumn())? shop : incorrectShop;
        } 
        else
        {
            gameObject.tag = "Grass";
            _spriteRenderer.sprite = grass;
        }
    }
}
