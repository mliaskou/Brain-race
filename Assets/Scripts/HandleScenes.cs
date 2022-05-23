using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class HandleScenes: MonoBehaviour
{
    public void PlayerNameEntry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
        
    }

    
    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }


    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void CarColorEntry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
    }
    public void ReturnBacktoMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }


}
