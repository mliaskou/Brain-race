using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PointsScore : MonoBehaviour
{
    public Text txt;
   

    private float minPoints = 1;
    private int maxPoints = 100;

    public float points = 0;

    private float pointsLengthOfLine;
    public LineChangeColor lineChangeColor;

    public CarController carController;

    public GameObject ReloadScenePanel;
    public void Start()
    {
        txt.text = "Points:" + points;
    }
    public void Update()
    {
        minPoints = (maxPoints / lineChangeColor.LengthOfLine())* carController.currentSpeed;
       
    }

    public void IncreaseScore()
    {
        if (points >= maxPoints)
        {
            points = maxPoints;
            txt.text = "Points:" + points;
            Debug.Log("Win");
           
        }

        if (points < maxPoints) 
          points += minPoints;
         
          Debug.Log(points);
          txt.text = "Points:" + Mathf.RoundToInt(points);
        
    }

    public void DecreaseScore()
    {
        points -=minPoints ;
        Debug.Log(" Losing" + points);
        txt.text = "Points:" + Mathf.RoundToInt(points);
        if (points <= minPoints)
        {
            points = 0;
            txt.text = "Points:" + Mathf.RoundToInt(points);
            GameOver();
        }
        
       
    }

    public void DecreaseObstaclePoints()
    {
        points -= 1;
        txt.text = "Points:" + points;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        
        carController.speed = 0;
        ReloadScenePanel.SetActive(true);
    }
    public void ReloadScene()
    {
        StartCoroutine("ReloadSceneAgain");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator ReloadSceneAgain()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("FirstScene");
    }
}
