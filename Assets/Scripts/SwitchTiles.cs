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
            _spriteRenderer.sprite = GetRow() ? shop : incorrectShop;
        } 
        else
        {
            gameObject.tag = "Grass";
            _spriteRenderer.sprite = grass;
        }
    }

   /* private RaycastHit2D[] Tiles()
    {
        var tiles = GetRow().Concat(GetColumn()).Concat(GetDiagonalAdjacent());
       /* var raycastHit2Ds = tiles.ToList();
        IEnumerable<RaycastHit2D> unique = raycastHit2Ds.Distinct(); 
        foreach (var t in tiles)
        {
            Debug.Log(t.collider.gameObject);
        }
        return tiles.ToArray();
    } */
}
