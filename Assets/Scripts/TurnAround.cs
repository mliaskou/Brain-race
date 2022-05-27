using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : MonoBehaviour
{
    public GameObject car;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        car.transform.Rotate(0.0f, -1f, 0.0f, Space.Self); // the car rotates in the scene when you choose color
    }
}
