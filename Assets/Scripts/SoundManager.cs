using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager BgInstance;
    public AudioSource audi; 
    private void Awake()
    {
        if (BgInstance != null && BgInstance != this)
        {
            Destroy(gameObject);
            return;
        }
        BgInstance = this;
        DontDestroyOnLoad(this);
    } 
    private void Start()
    {
        audi = GetComponent<AudioSource>();
    }
}
