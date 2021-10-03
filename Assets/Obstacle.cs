using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    public PointsScore pointsScore;
    public Text txt;
    public GameObject obstacle;

    private float powerUpStrength = 50f;

    public GameObject car;

    private void Start()
    {
        obstacle.SetActive(false);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Car1")
        {
            obstacle.SetActive(true);
            pointsScore.DecreaseObstaclePoints();
            txt.text = "You hit an obstacle";

            Rigidbody carRigidbody = car.GetComponent<Rigidbody>();
            carRigidbody.AddForce(car.transform.position * powerUpStrength, ForceMode.Impulse);
            Debug.Log("Collided with:" + car.name + "with power set to");
        }
    }

    private void OnCollisionExit(Collision other)
    {
        obstacle.SetActive(false);

    }
}
