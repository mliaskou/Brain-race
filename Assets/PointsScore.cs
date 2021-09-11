using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsScore : MonoBehaviour
{
    public Text txt;

    private float minPoints = 1;
    private int maxPoints = 100;

    private static float points = 0;

    float elapsed = 0;

    private float pointsLengthOfLine;
    public LineChangeColor lineChangeColor;

    public CarController carController;

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
            Debug.Log("Game Over");
        }
        
       
    }

    public void DecreaseObstaclePoints()
    {
        points -= 1;
        txt.text = "Points:" + points;
    }

}
