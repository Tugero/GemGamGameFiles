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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Red Gem" && locked == false)
        {
            Overlord.DarknessStart();
            RedGem.SetActive(true);
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
            Overlord.DarknessStart();
            GreenGem.SetActive(true);
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
            Overlord.DarknessStart();
            BlueGem.SetActive(true);
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
