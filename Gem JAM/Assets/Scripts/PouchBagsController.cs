using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouchBagsController : MonoBehaviour
{
    private int score =0;
    public GameObject ScorePouch;
    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Red Gem")
        {
            //score = score + 10;
            ScorePouch.GetComponent<GameController>().TotalScore += 10;
        }
        if (other.tag == "Green Gem")
        {
            //score = score + 50;
            ScorePouch.GetComponent<GameController>().TotalScore += 50;
        }
        if (other.tag == "Blue Gem")
        {
            //score = score + 100;
            ScorePouch.GetComponent<GameController>().TotalScore += 100;
        }
        if (other.tag =="Blue Gem" || other.tag == "Green Gem" || other.tag == "Red Gem")
        {
            Destroy(other.gameObject);
        }
        //ScorePouch.GetComponent<GameController>().TotalScore += score;
        //Destroy(other.gameObject);
    }
}
