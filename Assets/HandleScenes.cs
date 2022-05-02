using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class HandleScenes: MonoBehaviour
{
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("FirstScene");
        
    }

    
    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }


    public void ReloadScene()
    {
        StartCoroutine("ReloadSceneAgain");
    }

    IEnumerator ReloadSceneAgain()
    {
        yield return new WaitForSeconds(1f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");

    }

    public void ReturnBacktoMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
}
