using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSound : MonoBehaviour
{
    public GameObject[] sound; 
    private void Start()
    {
        if (SoundManager.BgInstance.audi.isPlaying)
        {
            sound[0].SetActive(true);
            sound[1].SetActive(false);
        }
        else
        {
            sound[0].SetActive(false);
            sound[1].SetActive(true);
        }
    }
    public void MusicToggle()
    {
        if (SoundManager.BgInstance.audi.isPlaying)
        {
            SoundManager.BgInstance.audi.Stop();
            sound[0].SetActive(false);
            sound[1].SetActive(true);
            
        }
        else
        {
            SoundManager.BgInstance.audi.Play();
            sound[0].SetActive(true);
            sound[1].SetActive(false);
        }
    }
}
