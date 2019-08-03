using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSaver : MonoBehaviour
{
    public GameObject Red;
    public GameObject Blue;
    public GameObject Green;
    public GameObject Coin;
    public GameObject RedCoin;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            Instantiate(Coin);
        }
        if (other.gameObject.tag == "Death Coin")
        {
            Destroy(other.gameObject);
            Instantiate(RedCoin);
        }
        if (other.gameObject.tag == "Red Gem")
        {
            Destroy(other.gameObject);
            Instantiate(Red);
        }
        if (other.gameObject.tag == "Blue Gem")
        {
            Destroy(other.gameObject);
            Instantiate(Blue);
        }
        if (other.gameObject.tag == "Green Gem")
        {
            Destroy(other.gameObject);
            Instantiate(Green);
        }
    }
}
