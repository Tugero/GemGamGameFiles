using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonController : MonoBehaviour
{
    public bool win;
    public GameObject[] Slots;
    public GameObject[] Lights;
    public Animator Door;
    public Sayer Simon;
    public int SlotCounter;
    public List<int> Choices = new List<int>();
    private int counter=0;
    private int RandNumb;
    public int counterII;
    public int CorrectSlots;
    public GodScript God;
    public GameObject Trapper;
    public GameObject DeathCoin;
    public AudioSource SoundPlayer;
    public AudioSource AnswerDingPlayer;
    public AudioClip Sound;
    public AudioClip Ding;

    void Start()
    {
        CorrectSlots = 0;
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
        if (Door != null)
        Door.speed = 0;
    }
    

    void Update()
    {
        if (this.name != "Door3")
        {
            God = GameObject.Find("GodController").GetComponent<GodScript>();
            while (Choices.Count > 0)
            {
                RandNumb = Random.Range(0, 8 - counter);
                Slots[counter].GetComponent<SimonSlots>().SlotID = Choices[RandNumb];
                Debug.Log("Removing: " + Choices[RandNumb] + " at Index: " + RandNumb);
                Choices.Remove(Choices[RandNumb]);
                counter++;
            }
            if (CorrectSlots == 9)
            {
                if (SoundPlayer.clip.name != "Win")
                {
                    SoundPlayer.clip = Sound;
                    SoundPlayer.Play();
                }
                Door.speed = .5f;
            }
            if (SlotCounter == 9 && CorrectSlots < 9)
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
            if (win == true)
            {
                if (SoundPlayer.clip.name != "Win")
                {
                    SoundPlayer.clip = Sound;
                    SoundPlayer.Play();
                }
                Door.speed = .5f;
            }
        }
    }

    IEnumerator DisplayPicks()
    {
        while (counterII < 9)
        {
            //Debug.Log(counterII);
            Lights[counterII].SetActive(true);
            AnswerDingPlayer.clip = Ding;
            AnswerDingPlayer.Play();
            yield return new WaitForSeconds(1);
            Lights[counterII].SetActive(false);
            counterII = counterII + 1;
        }
    }

    public void Death()
    {
        Debug.Log("Simon Level Completed!");
        God.NextLevel();
    }

}
