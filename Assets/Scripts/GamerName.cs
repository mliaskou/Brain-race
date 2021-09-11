using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamerName : MonoBehaviour
{
    public string nameOfPlayer;
    public string saveName;

    public Text InputText;
    public Text loadedName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nameOfPlayer = PlayerPrefs.GetString("name", "none");
        loadedName.text = nameOfPlayer;
    }

    public void SetName()
    {
        saveName = InputText.text;
        PlayerPrefs.SetString("name", "saveName");
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
