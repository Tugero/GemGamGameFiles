using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerSelector : MonoBehaviour
{
    public GameObject RedLazer;
    public GameObject BlueLazer;
    public GameObject GreenLazer;
    public int Randomizer;
    public bool Red = false;
    public bool Blue = false;
    public bool Green = false;


    void Start()
    {
        Randomizer = Random.Range(1, 4);
        if (Randomizer == 1)
        {
            if (BlueLazer != null)
                RedLazer.SetActive(true);
            Red = true;
        }
        if (Randomizer == 2)
        {
            if (BlueLazer != null)
                BlueLazer.SetActive(true);
            Blue = true;
        }
        if (Randomizer == 3)
        {
            if (BlueLazer != null)
                GreenLazer.SetActive(true);
            Green = true;
        }
    }
}
