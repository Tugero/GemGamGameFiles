using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSlots : MonoBehaviour
{
    public GameObject RedGem;
    public GameObject BlueGem;
    public GameObject GreenGem;
    public GridPuzzleController Overlord;
    public LazerSelector Noble;
    private bool locked = false;
    public GameObject NextLine;
    public GameObject Blocker;
    public AudioSource SoundPlayer;
    public AudioClip Sound;

    private void Start()
    {
        SoundPlayer = this.GetComponent<AudioSource>();
        SoundPlayer.clip = Sound;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Red Gem" && locked == false)
        {
            Blocker.SetActive(true);
            Overlord.DarknessStart();
            RedGem.SetActive(true);
            SoundPlayer.Play();
            locked = true;
            if (Noble.Red == true)
            {
                NextLine.SetActive(true);
                Overlord.Correctkeys += 1;
            }
            Destroy(other.gameObject);
        }
        if (other.tag == "Green Gem" && locked == false)
        {
            Blocker.SetActive(true);
            Overlord.DarknessStart();
            GreenGem.SetActive(true);
            SoundPlayer.Play();
            locked = true;
            if (Noble.Green == true)
            {
                NextLine.SetActive(true);
                Overlord.Correctkeys += 1;
            }
            Destroy(other.gameObject);
        }
        if (other.tag == "Blue Gem" && locked == false)
        {
            Blocker.SetActive(true);
            Overlord.DarknessStart();
            BlueGem.SetActive(true);
            SoundPlayer.Play();
            locked = true;
            if (Noble.Blue == true)
            {
                NextLine.SetActive(true);
                Overlord.Correctkeys += 1;
            }
            Destroy(other.gameObject);
        }
    }
}
