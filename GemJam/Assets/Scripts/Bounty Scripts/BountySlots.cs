using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BountySlots : MonoBehaviour
{
    public GameObject RedGem;
    public GameObject BlueGem;
    public GameObject GreenGem;
    private bool locked=false;
    public GameObject Overlord;
    public Animator Gate;
    public Animator Crusher;
    public Animator MovingSwitches;
    public AudioSource SoundPlayer;
    public AudioClip Sound;
    void Start()
    {
        RedGem.SetActive(false);
        BlueGem.SetActive(false);
        GreenGem.SetActive(false);
        Overlord.Equals("BountyPuzzle");
        locked = false;
        Crusher.speed = 0;
        MovingSwitches.speed = 0;
        SoundPlayer.clip = Sound;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Red Gem" && locked == false)
        {
            Gate.speed = 1;
            RedGem.SetActive(true);
            SoundPlayer.Play();
            locked = true;
            Crusher.speed = 1;
            MovingSwitches.speed = 1;
            Overlord.GetComponent<BountyPuzzle>().PlayerAnswer += 5;
            Overlord.GetComponent<BountyPuzzle>().SlotsUsed += 1;
            Destroy(other.gameObject);
        }
        if (other.tag == "Green Gem" && locked == false)
        {
            Gate.speed = 1;
            GreenGem.SetActive(true);
            SoundPlayer.Play();
            locked = true;
            Crusher.speed = 1;
            MovingSwitches.speed = 1;
            Overlord.GetComponent<BountyPuzzle>().PlayerAnswer += 50;
            Overlord.GetComponent<BountyPuzzle>().SlotsUsed += 1;
            Destroy(other.gameObject);
        }
        if (other.tag == "Blue Gem" && locked == false)
        {
            Gate.speed = 1;
            BlueGem.SetActive(true);
            SoundPlayer.Play();
            locked = true;
            Crusher.speed = 1;
            MovingSwitches.speed = 1;
            Overlord.GetComponent<BountyPuzzle>().PlayerAnswer += 100;
            Overlord.GetComponent<BountyPuzzle>().SlotsUsed += 1;
            Destroy(other.gameObject);
        }
    }
}
