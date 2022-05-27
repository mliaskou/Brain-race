using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class ReadScoreBoard : MonoBehaviour
{
    public GameObject scoreBoard;
    public Dictionary<string, int> thedictionary = new Dictionary<string, int>();
    // Start is called before the first frame update
    public void ShowScoreBoard()
    {
        scoreBoard.SetActive(true); 
    }

    public ReadScoreBoard()
    {
        if (File.Exists(@"myfile.txt") && File.ReadAllLines(@"myfile.txt").Length > 0)
        {
            thedictionary = File.ReadAllLines(@"myfile.txt") // Read the txt file and convert the information to the dictionary
                                       .Select(x => x.Split('='))
                                       .ToDictionary(x => x[0], x => System.Int32.Parse(x[1]));

            thedictionary = thedictionary.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        }
    }

    public void CloseScoreBoard()
    {
        scoreBoard.SetActive(false);
    }
}
