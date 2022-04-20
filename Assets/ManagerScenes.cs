using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ManagerScenes : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene("FirstScene");
    }
}
