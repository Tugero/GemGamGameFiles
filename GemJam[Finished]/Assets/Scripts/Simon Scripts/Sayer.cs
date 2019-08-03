using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sayer : MonoBehaviour
{
    public bool ShowAnswer;
    public SimonController Overlord;
    public GodScript God;
    public AudioSource SoundPlayer;
    public AudioClip Sound;

    private void OnTriggerEnter(Collider other)
    {
        SoundPlayer = this.GetComponent<AudioSource>();
        SoundPlayer.clip = Sound;
        if (other.tag == "Coin")
        {
            ShowAnswer = true;
            SoundPlayer.Play();
            Destroy(other.gameObject);
        }
        if (other.tag == "Death Coin")
        {
            God = GameObject.Find("GodController").GetComponent<GodScript>();
            God.Death();
        }
    }
}
