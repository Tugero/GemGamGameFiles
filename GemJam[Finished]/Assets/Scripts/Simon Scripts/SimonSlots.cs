using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSlots : MonoBehaviour
{
    public GameObject RedGem;
    public GameObject BlueGem;
    public GameObject GreenGem;
    public GameObject RL;
    public GameObject BL;
    public GameObject GL;
    public SimonController Overlord;
    private bool locked = false;
    public int SlotID;
    public AudioSource SoundPlayer;
    public AudioClip Sound;

    void Start()
    {
        Overlord = GameObject.Find("Simon Say's Puzzle").GetComponent<SimonController>();
        SoundPlayer.clip = Sound;
    }

    void Update()
    {
        if (SlotID == 1)
            RL.SetActive(true);
        if (SlotID == 2)
            GL.SetActive(true);
        if (SlotID == 3)
            BL.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Red Gem" && locked == false)
        {
            Overlord.SlotCounter += 1;
            RedGem.SetActive(true);
            SoundPlayer.Play();
            locked = true;
            if (SlotID == 1)
            {
                Overlord.CorrectSlots += 1;
            }
            Destroy(other.gameObject);
        }
        if (other.tag == "Green Gem" && locked == false)
        {
            Overlord.SlotCounter += 1;
            GreenGem.SetActive(true);
            SoundPlayer.Play();
            locked = true;
            if (SlotID == 2)
            {
                Overlord.CorrectSlots += 1;
            }
            Destroy(other.gameObject);
        }
        if (other.tag == "Blue Gem" && locked == false)
        {
            Overlord.SlotCounter += 1;
            BlueGem.SetActive(true);
            SoundPlayer.Play();
            locked = true;
            if (SlotID == 3)
            {
                Overlord.CorrectSlots += 1;
            }
            Destroy(other.gameObject);
        }
    }
}
