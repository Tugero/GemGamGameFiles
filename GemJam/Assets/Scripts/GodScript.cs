using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodScript : MonoBehaviour
{
    public GameObject StartParticles;
    public GameObject ExitParticles;
    public GameObject Player;
    public GameObject BountyLevel;
    public GameObject GridLevel;
    public GameObject SimonLevel;
    public Animator F2B;
    public Text PlayerStateText;
    public Text ScoreText;
    public int LevelsCompleted =0;
    //Prefabs
    public Transform PuzzleSpawner;
    public GameObject PlayButton;
    public GameObject[] PuzzleRooms;
    private int index;

    public void Start()
    {
        Player = GameObject.Find("Player");
        F2B = GameObject.FindWithTag("F2B").GetComponent<Animator>();
        PlayerStateText = GameObject.Find("Start Text").GetComponent<Text>();
        //PlayButton = GameObject.Find("Yes");
        StartParticles = GameObject.Find("StartParticles");
    }

    public void Update()
    {
        BountyLevel = GameObject.Find("Bounty Puzzle(Clone)");
        GridLevel = GameObject.Find("Grid Puzzle(Clone)");
        SimonLevel = GameObject.Find("Simon Puzzle(Clone)");
        if (ScoreText != null)
        ScoreText.text = "Rooms Completed: " + LevelsCompleted;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Red Gem")
        {
            Application.Quit();
            Debug.Log("Quiting Game");
            ExitParticles.SetActive(false);
        }

        if (other.gameObject.tag == "Green Gem")
        {
            Destroy(other.gameObject);
            F2B.Play("Fade2Black" ,-1,0);
            StartGame();
        }
    }

    private void StartGame()
    {
        //Debug.Log("Starting Game");
        StartParticles.SetActive(false);
        index = Random.Range(0, PuzzleRooms.Length);
        GameObject Room = PuzzleRooms[index];
        Instantiate(Room);
        Player.transform.position = new Vector3(-85.39439f, 38.93f, 8.950674f);
        StartParticles.SetActive(true);
        Instantiate(PlayButton, gameObject.transform);
    }

    public void NextLevel()
    {
        LevelsCompleted += 1;
        F2B.Play("Fade2Black", -1, 0);
        Player.transform.position = new Vector3(0, 0, 0);
        Destroy(BountyLevel);
        Destroy(GridLevel);
        Destroy(SimonLevel);
        index = Random.Range(0, PuzzleRooms.Length);
        GameObject Room = PuzzleRooms[index];
        Instantiate(Room);
        Player.transform.position = new Vector3(-85.39439f, 38.93f, 8.950674f);
    }

    public void Death()
    {
        Debug.Log("Player Has Died");
        PlayerStateText.text = "You have died\n in the Dungeon!";
        F2B.Play("Fade2Black", -1, 0);
        Player.transform.position = new Vector3(-59f, 38.93f, 8.950674f);
        StartParticles.SetActive(true);
        Destroy(BountyLevel);
        Destroy(GridLevel);
        Destroy(SimonLevel);
    }
}
