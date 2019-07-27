using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonController : MonoBehaviour
{
    public GameObject[] Slots;
    public GameObject[] Lights;
    public Animator Door;
    public Sayer Simon;
    public int SlotCounter;
    public List<int> Choices = new List<int>();
    private int counter;
    private int RandNumb;
    public int counterII;
    public int CorrectSlots;
    public GodScript God;
    public GameObject Trapper;
    public GameObject DeathCoin;

    void Start()
    {
        CorrectSlots = 0;
        counter = 0;
        counterII =0;
        Choices.Add(1);
        Choices.Add(1);
        Choices.Add(1);
        Choices.Add(2);
        Choices.Add(2);
        Choices.Add(2);
        Choices.Add(3);
        Choices.Add(3);
        Choices.Add(3);
        God = GameObject.Find("GodController").GetComponent<GodScript>();
        Door.speed = 0;
    }
    

    void Update()
    {
        God = GameObject.Find("GodController").GetComponent<GodScript>();
        while (counter < 9)
        {
            RandNumb = Random.Range(0, 8-counter);
            Slots[counter].GetComponent<SimonSlots>().SlotID = Choices[RandNumb];
            //Debug.Log("Removing: " + Choices[RandNumb] + " at Index: " + RandNumb);
            Choices.Remove(Choices[RandNumb]);
            counter = counter + 1;
        }
       if (CorrectSlots == 9)
        {
            Door.speed = 1;
        }
       if (SlotCounter ==9 && CorrectSlots < 9)
        {
            Trapper.SetActive(true);
            DeathCoin.SetActive(true);
        }
        if (Simon.ShowAnswer == true)
        {
            counterII = 0;
            //Debug.Log("Showing Answers");
            StartCoroutine(DisplayPicks());
            Simon.ShowAnswer = false;
        }
    }

    IEnumerator DisplayPicks()
    {
        while (counterII < 9)
        {
            //Debug.Log(counterII);
            Lights[counterII].SetActive(true);
            yield return new WaitForSeconds(1);
            Lights[counterII].SetActive(false);
            counterII = counterII + 1;
        }
    }

    public void Death()
    {
        Debug.Log("Bounty Level Completed!");
        God.NextLevel();
    }

}
