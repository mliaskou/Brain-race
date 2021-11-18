using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TriggerRound : MonoBehaviour
{
    private int round = 0;
    public Text finalScore;
    public GameObject finalScoreObject;
    public PointsScore pointScore;
    public int initialPoints;
    public int saveFinalPoints;
    public Text playerNameText;

    private void Start()
    {
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
        if(other.CompareTag("Player"))
        {
            round++;
            if(round> 2)
            {
                finalScoreObject.SetActive(true);
                finalScore.text = "Final score is:  " + Mathf.RoundToInt(pointScore.points);
                SetFinalScore();
                playerNameText.text = "PlayerName:" + PlayerPrefs.GetString("PlayerName");
            }
        }
    }
}
