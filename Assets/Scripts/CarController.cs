using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;
using System;

public class CarController : MonoBehaviour
{
    public float speed = 10;
    public float speedRotation = 0;
    public float brakes;

    public float currentSpeed;
    public float moveAside;

    private float horizontalInput;
    private float verticalInput;

    private bool isBreaking;

    [SerializeField] private float brakeForce = 0f;

    private float t;

    public Color red = Color.red;
    public Color blue = Color.blue;
    public Color green = Color.green;
    public Color yellow = Color.yellow;
    public Color white = Color.white;
    public GameObject cube;


    private float SteerAngle;
    public StateManager stateManager;

    [SerializeField] private float maxSteeringAngle = 110f;
    [SerializeField] private float minSteeringAngle = 40f;

    private Vector3 lastPosition;

    public Text speedTxt;
    private float powerUpStrength = 20f;

    public float speedMax;
    public float speedMin = 0f;

    
    private int timeStart =3;
    [SerializeField] Text timeText;
    [SerializeField] GameObject rightText;
    [SerializeField] GameObject leftText;
    [SerializeField] float timeLeft = 3.0f;
  
    public void Awake()
    {
        
        cube.GetComponent<MeshRenderer>().material.color = StateManager.carColor;
        
    }

    private void Update()
    {
      
    }
   

    private void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
        timeLeft = Mathf.Clamp(timeLeft, 0, 3);
        timeText.text = (timeLeft).ToString("0");
        if (timeLeft<=0)
        {
            GetInput();
            HandleMotor();
            HandleSteering();
            timeLeft = 0;
            timeText.enabled = false;

        }
         
    }

    public void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
    }
    private void HandleMotor()
    {
        
        transform.position += transform.forward * speed * Time.deltaTime;
        if (speed > speedMax)
        {
            speed = speedMax;
        }

        if (speed < speedMin)
        {
            speed = speedMin;
        }
        if (lastPosition.z > 0)
        {
            currentSpeed = Vector3.Distance(transform.position, lastPosition);
        }
        //moveAside = speed * horizontalInput;
        //oveAside *= Time.deltaTime;
        //transform.Translate(moveAside, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed = Mathf.Lerp(speed, 0, t);
            
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 2, 0) * Time.deltaTime * speed, Space.World);
            rightText.SetActive(true);
        }
        else
        {
            rightText.SetActive(false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, -2, 0) * Time.deltaTime * speed, Space.World);
            leftText.SetActive(true);
        }
        else
           
        {
            leftText.SetActive(false);
        }

        t += 0.2f *Time.fixedDeltaTime;
       if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            speed += 2;
        }
       else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            speed -= 2;
        }

       
        lastPosition = transform.position;

        speedTxt.text = "Speed:" + speed.ToString();
    }

    private float HandleSteering()
    {
        SteerAngle = maxSteeringAngle * horizontalInput;
        return SteerAngle;
    }


 

}
