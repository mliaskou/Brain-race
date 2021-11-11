using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameOfPlayer : MonoBehaviour
{
    public InputField textBox;
    

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
