using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int TotalScore;
    public Text Score;


    void Start()
    {
        Score.text = "Score: 0";
    }


    void Update()
    {
        if (Score != null)
        Score.text = "Score: " + TotalScore;
        if (Input.GetKey("Escape"))
        {
            Application.Quit();
        }
    }
}
