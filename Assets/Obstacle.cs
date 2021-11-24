using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    public PointsScore pointsScore;
    public Text txt;
    public GameObject obstacleText;
    public LifePanelAdd lifepanelAdd;

    public int number = 1;

    private float powerUpStrength = 50f;

    public GameObject car;

    private void Start()
    {
        obstacleText.SetActive(false);
        
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "_ar")
        {
            obstacleText.SetActive(true);
            pointsScore.DecreaseObstaclePoints();
            obstacleText.GetComponentInChildren<Text>().text = "You hit an obstacle";

            for (int i = lifepanelAdd.Slots.Length -1; i >= 0 ; i--)
            {
                if (lifepanelAdd.Slots[i].activeSelf == true)
                {
                    lifepanelAdd.Slots[i].SetActive(false);
                    break;
                }
            }
            Rigidbody carRigidbody = car.GetComponent<Rigidbody>();
            carRigidbody.AddForce(car.transform.position * powerUpStrength, ForceMode.Impulse);
            Debug.Log("Collided with:" + car.name + "with power set to");
            this.gameObject.SetActive(false);
            obstacleText.SetActive(false);

        }
    }

}
