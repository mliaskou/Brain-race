using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    public PointsScore pointsScore;
    public Text txt;
    public GameObject obstacle;
    public LifePanelAdd lifepanelAdd;

    public int number = 1;

    private float powerUpStrength = 50f;

    public GameObject car;

    private void Start()
    {
        obstacle.SetActive(false);
        number = Random.Range(0, lifepanelAdd.Slots.Length - 1);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "_ar")
        {
            obstacle.SetActive(true);
            pointsScore.DecreaseObstaclePoints();
            txt.text = "You hit an obstacle";

            lifepanelAdd.Slots[number].SetActive(false);
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
