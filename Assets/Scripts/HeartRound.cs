using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRound : MonoBehaviour
{
    
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Rotate(0.0f, 0f, 1.0f, Space.Self); // rotates the heart around itself
    }

}
