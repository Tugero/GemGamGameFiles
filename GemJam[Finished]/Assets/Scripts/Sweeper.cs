using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweeper : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
            Destroy(other.gameObject);
        if (other.gameObject.tag == "Red Gem")
            Destroy(other.gameObject);
        if (other.gameObject.tag == "Blue Gem")
            Destroy(other.gameObject);
        if (other.gameObject.tag == "Green Gem")
            Destroy(other.gameObject);
    }
}
