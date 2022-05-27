using UnityEngine;
using UnityEngine.UI;

public class PointsScore : MonoBehaviour
{
    public Text txt;
   

    private float minPoints = 1;
    private int maxPoints = 100;

    public float points = 10;

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
        minPoints = (maxPoints / lineChangeColor.LengthOfLine())* carController.currentSpeed; // The points depends on the length that the car crosses
       
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
          points += minPoints;// increase the player score when the player crosses the line
         
          Debug.Log(points);
          txt.text = "Points:" + Mathf.RoundToInt(points);
        
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        
        carController.speed = 0;
        ReloadScenePanel.SetActive(true);
    }
   
}
