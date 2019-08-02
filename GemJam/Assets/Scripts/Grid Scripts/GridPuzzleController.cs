using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPuzzleController : MonoBehaviour
{
    public bool win;
    public int Correctkeys;
    public Animator DoorFall;
    public GodScript God;
    public GameObject Self;

    //Kill FX
    public Animator Darkness;
    public Animator Tortch_1;
    public GameObject Fire1;
    public Animator Tortch_2;
    public GameObject Fire2;
    public Animator Tortch_3;
    public GameObject Fire3;
    public Animator Tortch_4;
    public GameObject Fire4;
    public Animator Light;
    public GameObject LightObj;
    public GameObject Blocker;
    public AudioSource SoundPlayer;
    public AudioClip Sound;


    private void Start()
    {
        if (Darkness != null)
        Darkness.speed=0;
        if (Tortch_1 != null)
            Tortch_1.speed = 0;
        if (Tortch_2 != null)
            Tortch_2.speed = 0;
        if (Tortch_3 != null)
            Tortch_3.speed = 0;
        if (Tortch_4 != null)
            Tortch_4.speed = 0;
        if (Light != null)
            Light.speed = 0;
        if (DoorFall != null)
        DoorFall.speed = 0;
        God = GameObject.Find("GodController").GetComponent<GodScript>();
        Self = GameObject.Find("Grid Puzzle(Clone)");
    }

    void Update()
    {
        if (Correctkeys == 4)
        {
            if (SoundPlayer.clip.name != "Win")
            {
                SoundPlayer.clip = Sound;
                SoundPlayer.Play();
            }
            DoorFall.speed = .5f;
            if (Darkness != null)
            Darkness.SetFloat("Reverse",-2);
            if (Light != null)
            {
                LightObj.SetActive(true);
                Light.speed = 1;
                Blocker.SetActive(false);
            }
        }
        if (win == true)
        {
            if (SoundPlayer.clip.name != "Win")
            {
                SoundPlayer.clip = Sound;
                SoundPlayer.Play();
            }
            DoorFall.speed = .5f;
        }
    }

    public void Death()
    {
        Debug.Log("Grid Level Completed!");
        God.NextLevel();
    }

    public void Dead() 
    {
        God.Death();
     }


    public void DarknessStart()
    {
        Darkness.speed = 1;
    }
    public void Tortch01()
    {
        if (Tortch_1 != null)
            Tortch_1.speed = 1;
    }
    public void Tortch02()
    {
        if (Tortch_2 != null)
            Tortch_2.speed = 1;
    }
    public void Tortch03()
    {
        if (Tortch_3 != null)
            Tortch_3.speed = 1;
    }
    public void Tortch04()
    {
        if (Tortch_4 != null)
            Tortch_4.speed = 1;
    }
    public void TorchFX()
    {
        if (Fire1 != null && Fire2 != null && Fire3 != null && Fire4 != null)
        {
            Fire1.SetActive(false);
            Fire2.SetActive(false);
            Fire3.SetActive(false);
            Fire4.SetActive(false);
        }
    }


}
