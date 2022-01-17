using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System.Linq;

public class TriggerRound : MonoBehaviour
{
    private int round = 0;
    
    public PointsScore pointScore;
    public int initialPoints;
    public int saveFinalPoints;
    public GameObject scoreBoard;
    //public Text playerNameText;

    public Dictionary<string, int> thedictionary = new Dictionary<string, int>();
    public Vector2 scrollPosition = Vector2.zero;
    private void Awake()
    {
        if (File.Exists(@"myfile.txt") && File.ReadAllLines(@"myfile.txt").Length>0)
        {
            thedictionary = File.ReadAllLines(@"myfile.txt")
                                       .Select(x => x.Split('='))
                                       .ToDictionary(x => x[0], x => Int32.Parse(x[1]));

            thedictionary = thedictionary.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }
        pointScore = GameObject.FindObjectOfType<PointsScore>();
    }


    public void Update()
    {
        initialPoints = PlayerPrefs.GetInt("finalPoints", 0);
    }


    public void SetFinalScore()
    {
        saveFinalPoints = Mathf.RoundToInt(pointScore.points);
        PlayerPrefs.SetInt("finalPoints", saveFinalPoints);


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            round++;
            if (round >= 1)
            {
                /*finalScoreObject.SetActive(true);
                finalScore.text = "Final score is:  " + Mathf.RoundToInt(pointScore.points);
                 SetFinalScore();
                playerNameText.text = "PlayerName:" + PlayerPrefs.GetString("PlayerName");*/
                string playerName = PlayerPrefs.GetString("PlayerName");
                int Score = Mathf.RoundToInt(pointScore.points);
                thedictionary.Add(playerName, Score);
                File.WriteAllLines("myfile.txt", thedictionary.Select(x => x.Key + "=" + x.Value).ToArray());
                scoreBoard.SetActive(true);
                //OnGUI();
            }
        }
    }



    /*void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 300, 100, 100));
        scrollPosition = GUILayout.BeginScrollView(scrollPosition);
        foreach (KeyValuePair<string, int> pair in thedictionary)
        {
            
            GUILayout.Label(pair.Key + " : " + pair.Value);
            if (pair.Value > 0)
            {
                if (GUILayout.Button("Reduce", GUILayout.Width(70)))
                {
                    thedictionary[pair.Key] = thedictionary[pair.Key] - 1;
                }
            }
            GUILayout.EndHorizontal();
        }

        foreach (KeyValuePair<string, int> d in thedictionary)
        {

        }

    }*/
}
