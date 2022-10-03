using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager AM;
    public AudioSource BGM,victory;
    public AudioSource[] SFXs;
    private void Awake()
    {
     AM = this;
    }
    public void PlayVictoryMusic() 
    {
     BGM.Stop();
     victory.Play();
    }
    public void PlaySFX(int sfxNumber) 
    {
     SFXs[sfxNumber].Stop();
     SFXs[sfxNumber].Play();
    }
    public void StopSFX(int sfxNumber)
    {
     SFXs[sfxNumber].Stop();
    }
}
