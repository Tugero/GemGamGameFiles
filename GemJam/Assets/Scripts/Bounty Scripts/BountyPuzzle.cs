using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BountyPuzzle : MonoBehaviour
{
    public int RedCost =5;
    public int GreenCost =50;
    public int BlueCost = 100;
    public int TotalCost;
    public int PlayerAnswer;
    public int SlotsUsed;
    public Text Targetnumber;
    public GameObject Door;
    private int[] array;
    private int slotOne;
    private int slotTwo;
    private int slotThree;
    private int slotFour;
    public Animator Crusher;
    public Animator MovingSwitches;
    public Animator DoorFall;
    public GodScript God;
    public GameObject Self;

    void Start()
    {
        if (DoorFall != null)
        DoorFall.speed = 0;
        array = new int[3];
        array[0] = 5;
        array[1] = 50;
        array[2] = 100;
        slotOne = array[Random.Range(0, 2)];
        slotTwo = array[Random.Range(0, 2)];
        slotThree = array[Random.Range(0, 2)];
        slotThree = array[Random.Range(0, 2)];
        slotFour = array[Random.Range(0, 2)];
        God = GameObject.Find("GodController").GetComponent<GodScript>();
        Self = GameObject.Find("Bounty Puzzle(Clone)");
    }


    void Update()
    {
        TotalCost = slotOne + slotTwo + slotThree+slotFour;
        if (Targetnumber != null)
        Targetnumber.text = ""+ TotalCost;

        if (PlayerAnswer == TotalCost && SlotsUsed ==4)
        {
            //Door.SetActive(false);
            Crusher.speed = 0;
            MovingSwitches.speed = 0;
            if (DoorFall != null)
                DoorFall.speed = 1;
            God.LevelsCompleted += 1;
        }
        if (PlayerAnswer < TotalCost && SlotsUsed == 4)
        {
            Targetnumber.text = "Your answer was too Low!";
        }
        if (PlayerAnswer > TotalCost && SlotsUsed == 4)
        {
            Targetnumber.text = "Your answer was too High!";
        }
    }

    public void Death()
    {
        Debug.Log("Bounty Level Completed!");
        God.NextLevel();
    }
}
