using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    public PointsScore pointsScore;
    public Text txt;
    public GameObject obstacle;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "car1")
        {
            obstacle.SetActive(true);
            pointsScore.DecreaseObstaclePoints();
            txt.text = "You hit an obstacle";
        }
    }

    private void OnCollisionExit(Collision other)
    {
        obstacle.SetActive(false);

    }

}
