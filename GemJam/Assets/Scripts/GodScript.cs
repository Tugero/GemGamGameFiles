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
    public GameObject GodSweeper;
    public Animator F2B;
    public Text PlayerStateText;
    //public Text ScoreText;
    public int LevelsCompleted =0;
    private int index;
    public AudioSource MenuMusic;
    public AudioClip menuMusic;
    public ScoreBoard ScoreController;

    //Prefabs
    public Transform PuzzleSpawner;
    public GameObject PlayButton;
    public GameObject[] PuzzleRooms;


    public void Start()
    {
        ScoreController = GameObject.Find("Score Board").GetComponent<ScoreBoard>();
        MenuMusic = GameObject.Find("Menu Music").GetComponent<AudioSource>();
        if (GodSweeper != null)
            GodSweeper.SetActive(false);
        LevelsCompleted = 0;
        Player = GameObject.Find("Player");
        F2B = GameObject.FindWithTag("F2B").GetComponent<Animator>();
        PlayerStateText = GameObject.Find("Start Text").GetComponent<Text>();
        StartParticles = GameObject.Find("StartParticles");
    }

    public void Update()
    {
        BountyLevel = GameObject.Find("Bounty Puzzle(Clone)");
        GridLevel = GameObject.Find("Grid Puzzle(Clone)");
        SimonLevel = GameObject.Find("Simon Puzzle(Clone)");

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "no")
        {
            Application.Quit();
            Debug.Log("Quiting Game");
            ExitParticles.SetActive(false);
        }

        if (other.gameObject.tag == "Yes")
        {
            Destroy(other.gameObject);
            F2B.Play("Fade2Black" ,-1,0);
            StartGame();
        }
    }

    private void StartGame()
    {
        LevelsCompleted = 0;
        //Debug.Log("Starting Game");
        StartParticles.SetActive(false);
        index = Random.Range(0, PuzzleRooms.Length);
        GameObject Room = PuzzleRooms[index];
        Instantiate(Room);
        MenuMusic.Stop();
        F2B.Play("Fade2Black", -1, 0);
        Player.transform.position = new Vector3(-85.39439f, 38.93f, 8.950674f);
        StartParticles.SetActive(true);
        Instantiate(PlayButton, gameObject.transform);
        ScoreController.StartGame();
    }

    public void NextLevel()
    {
        F2B.Play("Fade2Black", -1, 0);
        Player.transform.position = new Vector3(0, 0, 0);
        Destroy(BountyLevel);
        Destroy(GridLevel);
        Destroy(SimonLevel);
        if (GodSweeper != null)
            GodSweeper.SetActive(true);
        LevelsCompleted += 1;
        ScoreController.ChangeScore(ScoreController.PersonalID, LevelsCompleted);
        ScoreController.Sorter();
        //Debug.Log(ScoreController.GetScore(ScoreController.PersonalID));
        index = Random.Range(0, PuzzleRooms.Length);
        if (GodSweeper != null)
            GodSweeper.SetActive(false);
        GameObject Room = PuzzleRooms[index];
        Instantiate(Room);
        Player.transform.position = new Vector3(-85.39439f, 38.93f, 8.950674f);
    }

    public void Death()
    {
        Debug.Log("Player Has Died");
        PlayerStateText.text = "You have died\n in the Dungeon!";
        F2B.Play("Fade2Black", -1, 0);
        MenuMusic.clip = menuMusic;
        MenuMusic.Play();
        Player.transform.position = new Vector3(-59f, 38.93f, 8.950674f);
        StartParticles.SetActive(true);
        Destroy(BountyLevel);
        Destroy(GridLevel);
        Destroy(SimonLevel);
        ScoreController.IDAssigner();
        ScoreController.Sorter();
    }

}
