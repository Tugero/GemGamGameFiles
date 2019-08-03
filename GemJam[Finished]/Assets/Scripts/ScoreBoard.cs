using System.Collections;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class ScoreBoard : MonoBehaviour
{
    Dictionary<int,int> DelverScores;

    public Text YourScore;
    public Text HighScores;
    private int TotalDelvers;
    public int PersonalID;
    private List<int> IDs = new List<int>();
    private List<int> Scores = new List<int>();
    private int Counter=0;


    void Start()
    {
        LoadStates();
        IDAssigner();
        YourScore.text = "How far will you go...";
        // Test Code
        /*
        SetScore(9999999, 1);
        SetScore(2, 4);
        SetScore(3, 2);
        SetScore(4, 5);
        SetScore(5, 3);
        */
      Sorter();
    }
    public void StartGame() 
    {
        if (YourScore != null)
            YourScore.text = "Previous Delver #" + PersonalID + " \n cleared: " + GetScore(PersonalID) + " rooms.";
    }

    public void IDAssigner()
    {
        if (TotalDelvers < 1)
        {
            TotalDelvers = 1;
            PersonalID = 1;
            SetScore(PersonalID, 0);
            return;
        }

        TotalDelvers += 1;
        PersonalID = TotalDelvers;
        SetScore(PersonalID, 0);
        Debug.Log("Player ID: " + PersonalID);
    }

    public void SaveStates() 
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Scores.dat");
        PlayerScores Save = new PlayerScores();
        Save.TotalDelvers = TotalDelvers;
      //Save.Top5ID = IDs;
     // Save.Top5Scores = Scores;
        Save.DelverScores = DelverScores;
        bf.Serialize(file, Save);
        file.Close();
    }

    public void LoadStates() 
    {
        if(File.Exists(Application.persistentDataPath + "/Scores.dat")) 
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Scores.dat", FileMode.Open);
            PlayerScores Load = (PlayerScores)bf.Deserialize(file);
            file.Close();
          //IDs = Load.Top5ID;
          //Scores = Load.Top5Scores;
            TotalDelvers = Load.TotalDelvers;
            DelverScores = Load.DelverScores;
          //for (int i = 0; i < Scores.Count; i++)
              //SetScore(IDs[i], Scores[i]);
        }
    }


    public void Sorter()
    {
        IDs.Clear();
        Scores.Clear();
        //Generate Both Lists
         var TopScores = DelverScores.OrderByDescending(pair => pair.Value).Take(5);
        foreach (KeyValuePair<int, int> kvp in TopScores)
        {
            IDs.Add(kvp.Key);
            Scores.Add(kvp.Value);
        }

      //Scores.Reverse();
      //IDs.Reverse();
        if (IDs.Count == 0)
            HighScores.text = "Top 5 Delvers Go Here";
        if (IDs.Count == 1)
            HighScores.text = "#" + IDs[0] + "[" + Scores[0] + "]";
        if (IDs.Count == 2)
            HighScores.text = "#" + IDs[0] + "[" + Scores[0] + "]" +
                            "\n#" + IDs[1] + "[" + Scores[1] + "]";
        if (IDs.Count == 3)
            HighScores.text = "#" + IDs[0] + "[" + Scores[0] + "]" +
                            "\n#" + IDs[1] + "[" + Scores[1] + "]" +
                            "\n#" + IDs[2] + "[" + Scores[2] + "]";
        if (IDs.Count == 4)
            HighScores.text = "#" + IDs[0] + "[" + Scores[0] + "]" +
                            "\n#" + IDs[1] + "[" + Scores[1] + "]" +
                            "\n#" + IDs[2] + "[" + Scores[2] + "]" +
                            "\n#" + IDs[3] + "[" + Scores[3] + "]"; 
        if (IDs.Count >= 5)
            HighScores.text = "#" + IDs[0] + "[" + Scores[0] + "]" +
                            "\n#" + IDs[1] + "[" + Scores[1] + "]" +
                            "\n#" + IDs[2] + "[" + Scores[2] + "]" +
                            "\n#" + IDs[3] + "[" + Scores[3] + "]" +
                            "\n#" + IDs[4] + "[" + Scores[4] + "]";
    }

    void Init()
    {
        if (DelverScores != null)
            return;
        DelverScores = new Dictionary<int, int>();
    }

    public int GetScore(int ID)
    {
        Init();
        if (DelverScores.ContainsKey(ID) == false)
            return -404;
        return DelverScores[ID];
    }

    public void SetScore(int ID, int Score) 
    {
        Init();
        if (DelverScores.ContainsKey(ID) == false)
            DelverScores[ID] = new int();
        DelverScores[ID] = Score;
    }

    public void ChangeScore(int ID, int Amount)
    {
        Init();
        SetScore(ID, Amount);
    }
}

[Serializable]
class PlayerScores
{
    public int TotalDelvers;
  //public List<int> Top5ID;
  //public List<int> Top5Scores;
    public Dictionary<int, int> DelverScores;
}
