using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System.Linq;

public class TriggerRound : ReadScoreBoard
{
    private int round = 0;
    
    public PointsScore pointScore;
    public int initialPoints;
    public int saveFinalPoints;
    private int slotActive =0;
    //public Text playerNameText;

    public LifePanelAdd lifepanelAdd;
    public CarController carController;
   

    public Vector2 scrollPosition = Vector2.zero;

    [SerializeField] GameObject replayMenu;

    public void Update()
    {
        initialPoints = Player.Instance.getPlayerScore();
    }


    public void SetFinalScore()
    {
        
        Player.Instance.setPlayerScore(saveFinalPoints);


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            round++;
            if (round >= 2)
            {
                string playerName = Player.Instance.getPlayerName();
                int Score = Mathf.RoundToInt(pointScore.points);

                if(thedictionary.ContainsKey(playerName)) // if the player already exists, find it and 
                {
                    if(thedictionary[playerName] < Score) // compare the new score to the previous one
                    {
                        thedictionary[playerName] = Score; // set the current score if it is higher
                    }
                    
                }
                else // if it does not exist, add the playername and the score
                {
                    thedictionary.Add(playerName, Score);
                } 
                //thedictionary.Add(playerName, Score);
                File.WriteAllLines("myfile.txt", thedictionary.Select(x => x.Key + "=" + x.Value).ToArray());
                
                foreach( GameObject slot in lifepanelAdd.Slots)
                {
                    if(slot.activeSelf)
                    {
                        slotActive++;
                    }

                }

                if ( slotActive > 0) // If the player has at least one heart, then wins
                {
                    Debug.Log("You won");
                    carController.speed = 0;
                    scoreBoard.SetActive(true);
                    
                }
               
            }
        }
    }

    public void DisplayReloadScene()
    {
        replayMenu.SetActive(true);
        
    }
}
