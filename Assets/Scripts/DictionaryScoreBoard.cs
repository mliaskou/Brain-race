using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DictionaryScoreBoard : MonoBehaviour
{
    public GameObject playerScore; // Assign the username, score

    public ReadScoreBoard readScoreBoard; // Take the values assigned in dictionary


    public void OnEnable()
    {
        int place = 1;

        foreach (KeyValuePair<string, int> pair in readScoreBoard.thedictionary)
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
