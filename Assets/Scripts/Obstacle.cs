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
    public CarController carController;
    public GameObject car;
    public int number = 1;

    public GameObject carPosition;

    public int forceApplied = 2;
    
    /*public void Start()
    {
        obstacleText.SetActive(false);
        
    }*/



    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "_ar")
        {
            //obstacleText.SetActive(true);
            Rigidbody obstacleRigidbody = this.gameObject.GetComponent<Rigidbody>();
            int carSpeed = (int)carController.speed;
            Vector3 awayfromObstacle = ( carPosition.gameObject.transform.position- this.transform.position );
            obstacleRigidbody.AddForce(awayfromObstacle * forceApplied, ForceMode.Impulse);
            //obstacleRigidbody.MovePosition(this.transform.position * carSpeed);
        }

    }  
        
        
       /* private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "_ar")
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
            
            
            obstacleText.SetActive(false);

        }
    }*/

}
