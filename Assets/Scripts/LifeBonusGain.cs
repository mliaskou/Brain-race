using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class LifeBonusGain : MonoBehaviour
{
    public GameObject obstacleText;
    
    public LifePanelAdd lifePanelAdd;
    public CarController carController;
    public GameObject car;

    public int forceApplied = 2;

    public LifePanelAdd lifepanelAdd;
    public PointsScore pointsScore;

    private bool livesAreActive = false;
    public void Start()
    {
        obstacleText.SetActive(false);


        
    }

    public void Update()
    {
        for (int i = 0; i < lifePanelAdd.Slots.Length; i++) // If the lives reach zero, then the game is over
        {
            if (lifePanelAdd.Slots[i].activeSelf == true)
            {
                livesAreActive = true;
                break;
            }
            else
            {
                livesAreActive = false;
                
            }

            Debug.Log("IsEmpty");
        }

        if (livesAreActive ==false)
        {
            pointsScore.GameOver();
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Heart"))
        {
            for (int i = 0; i <lifePanelAdd.Slots.Length; i++)
            {
                if (lifePanelAdd.Slots[i].activeSelf == false)
                {
                    lifePanelAdd.Slots[i].SetActive(true);
                    
                    break;
                }

                
            }

            Destroy(other.gameObject);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            obstacleText.SetActive(true);
            Rigidbody obstacleRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayfromObstacle = (collision.gameObject.transform.position);
            obstacleRigidbody.AddForce(awayfromObstacle * forceApplied, ForceMode.Impulse);
            
        }

    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            obstacleText.SetActive(true);
            obstacleText.GetComponentInChildren<Text>().text = "You hit an obstacle";
          }
        for (int i = lifepanelAdd.Slots.Length - 1; i >= 0; i--)
        {

            if (lifepanelAdd.Slots[i].activeSelf == true)
            {
                lifepanelAdd.Slots[i].SetActive(false);


                break;
            }
        }
            
        

        obstacleText.SetActive(false);
    }
}
