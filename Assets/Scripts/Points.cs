using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Points : MonoBehaviour
{
    public PointsScore pointScore;
    private  bool isCollided;
    public GameObject carBody;
    
    LineRenderer linerenderer;
    public GameObject line;
    private void Start()
    {
        linerenderer = GetComponent<LineRenderer>();
        LineRenderer lineRenderer = line.GetComponent<LineRenderer>();
      
    }

    private void Update()
    {
        if(isCollided == false)
        {
            //pointScore.DecreaseScore();
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isCollided = true;
            pointScore.IncreaseScore();
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollided = true;
            pointScore.IncreaseScore();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isCollided = false;
            //pointScore.DecreaseScore();
        }
    }

}
