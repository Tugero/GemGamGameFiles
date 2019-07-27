using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sayer : MonoBehaviour
{
    public bool ShowAnswer;
    public SimonController Overlord;
    public GodScript God;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            ShowAnswer = true;
            Destroy(other.gameObject);
        }
        if (other.tag == "Death Coin")
        {
            God = GameObject.Find("GodController").GetComponent<GodScript>();
            God.Death();
        }
    }
}
