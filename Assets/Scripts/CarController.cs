using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;
using System;

public class CarController : MonoBehaviour
{
    public float speed = 10;
    public float brakes;

    public float currentSpeed;

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


    public Text speedTxt;
    private float powerUpStrength = 20f;

    public float speedMax;
    public float speedMin = 0f;

    [SerializeField] Text timeText;
    [SerializeField] GameObject rightText;
    [SerializeField] GameObject leftText;
    [SerializeField] float timeLeft = 3.0f;
    public Rigidbody rb;

    public void Awake()
    {
        cube.GetComponent<MeshRenderer>().material.color = Player.Instance.GetCarColor();
        

    }

    private void FixedUpdate() // We use FixedUpdate when we use Physics
    {
        timeLeft -= Time.deltaTime; // Set the timer
        timeLeft = Mathf.Clamp(timeLeft, 0, 3);
        timeText.text = (timeLeft).ToString("0");
        if (timeLeft <= 0)
        {
            GetInput();
            HandleMotor();
            timeLeft = 0;
            timeText.enabled = false;

        }

    }

    public void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");// Take Horizontal Axis 
        verticalInput = Input.GetAxis("Vertical"); // Take Vertical Axis

    }
    private void HandleMotor()
    {

        transform.position += transform.forward * speed * Time.deltaTime; // The car starts to move when the game begins
        if (speed > speedMax) // the speed cannot be above 50
        {
            speed = speedMax;
        }

        if (speed < speedMin)// the speed cannot be below 0
        {
            speed = speedMin;
        }



        if (Input.GetKeyDown(KeyCode.Space)) // stop  the car if press space
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

        t += 0.2f * Time.fixedDeltaTime;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            speed += 2;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            speed -= 2;
        }

        speedTxt.text = "Speed:" + speed.ToString();
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collision!");
        if (col.gameObject.name == "obstacle")
        {
            col.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward*speed, ForceMode.Impulse);
        }
    }

}
