using UnityEngine;

public class SwitchTiles : MonoBehaviour
{
    public Sprite grass, shop;
    private SpriteRenderer _spriteRenderer; 
    void Start ()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); 
        if (_spriteRenderer.sprite == null)
            _spriteRenderer.sprite = grass;
    }

    private void OnMouseDown()
    {
        if (_spriteRenderer.sprite == grass)
        {
            _spriteRenderer.sprite = shop;
        } 
        else
        {
            _spriteRenderer.sprite = grass;
        }
    }
}
