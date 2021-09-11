using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameOfPlayer : MonoBehaviour
{
    public string NamePlayer;
    public string SaveName;

    public Text InputText;
    public Text LoadText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NamePlayer = PlayerPrefs.GetString("name", "none");
        LoadText.text = NamePlayer;
    }

    public void SetName()
    {

        SaveName = InputText.text;
        PlayerPrefs.SetString("name", "SaveName");
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
