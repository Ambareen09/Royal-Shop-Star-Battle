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
        _spriteRenderer.sprite = _spriteRenderer.sprite == grass ? shop : grass;
    }
}
