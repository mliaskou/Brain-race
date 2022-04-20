using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class NameOfPlayer : MonoBehaviour
{
    public InputField textBox;
    TriggerRound triggerRound;
    [SerializeField] string playerName;

    public Dictionary<string, int> thedict = new Dictionary<string, int>();

    void Awake()
    {

        /*if (File.Exists(@"myfile.txt") && File.ReadAllLines(@"myfile.txt").Length > 0)
        {
            thedict = File.ReadAllLines(@"myfile.txt")
                                       .Select(x => x.Split('='))
                                       .ToDictionary(x => x[0], x => int.Parse(x[1]));
        }*/
    }
   

    void Update()
    {
        /*if(!thedict.ContainsKey(textBox.text))
        {
            Debug.Log("Go on");
        }
        else
        {
            textBox.text = "";
            Debug.Log("Rewrite");
        }*/

    }
    public void ClickButton()
    {
        
            PlayerPrefs.SetString("PlayerName", textBox.text);
        
        Debug.Log("Your name is: " + PlayerPrefs.GetString("PlayerName"));
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
