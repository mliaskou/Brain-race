using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    public PointsScore pointsScore;
    public Text txt;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "car1")
        {
            pointsScore.DecreaseObstaclePoints();
            txt.text = "You hit an obstacle";
        }
    }
}
