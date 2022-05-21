using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class GetText : MonoBehaviour
{

    public GameObject playerScore;

    public TriggerRound triggerRound;
    //public ReadScoreBoard readScoreBoard;

    public void OnEnable()
    {
        int place = 1;

        foreach(KeyValuePair<string, int > pair in triggerRound.thedictionary)
        {
            GameObject scoreEntry = (GameObject)Instantiate(playerScore);// create in memory
            scoreEntry.transform.SetParent(this.transform);//shows playerprefs as child of ScoreList
            scoreEntry.transform.Find("Username").GetComponent<Text>().text = pair.Key;//dictionary name-key
            scoreEntry.transform.Find("Score").GetComponent<Text>().text = pair.Value.ToString();//dictionary value
            scoreEntry.SetActive(true);//to show the exact prefabs not one more 
            scoreEntry.transform.Find("Place").GetComponent<Text>().text = place.ToString();
            place++;

        }

    }
}
