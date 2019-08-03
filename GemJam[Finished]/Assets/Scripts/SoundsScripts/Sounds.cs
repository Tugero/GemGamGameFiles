using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource SoundPlayer;
    public AudioClip Sound;

    public void Start()
    {
        if  (SoundPlayer == null)
        SoundPlayer = this.GetComponent<AudioSource>();
    }

    public void SoundsPlay()
    {
        SoundPlayer.clip = Sound;
        SoundPlayer.Play();
    }
    public void SoundsStop()
    {
        SoundPlayer.Stop();
    }

}
