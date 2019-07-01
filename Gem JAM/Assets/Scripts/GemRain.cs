using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemRain : MonoBehaviour
{
    public int RandomGemSelector = 0;
    public Transform Wizard;
    public GameObject[] Gems;
    private GameObject Gem;
    void Start()
    {
        StartCoroutine(GemSpawner());
    }

    void Update()
    {
       //StartCoroutine(GemSpawner());
    }

        IEnumerator GemSpawner()
        {
       while (true)
        {
            yield return new WaitForSeconds(1);
            //Debug.Log("Numbers Scrambled");
            Gem = Gems[Random.Range(0, Gems.Length)]; 
            Instantiate(Gem, Wizard.position, Wizard.rotation);
            Gem = null; 
        }
    }
    }
