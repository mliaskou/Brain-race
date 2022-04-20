using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public StateManager Instance;
    public GameObject cube;
    public GameObject car;
    public Color red = Color.red;
    public Color blue = Color.blue;
    public Color green = Color.green;
    public Color yellow = Color.yellow;
    public Color white = Color.white;

    public float turnSpeed = 2;
    public GameObject prefab;

    
    public static Color carColor;

    public GameObject line;

    public Text playerTxt;
    
    void Awake()
    {
        
        // if the singleton hasn't been initialized yet
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;//Avoid doing anything else
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        
    }

    private void Start()
    {
        NameOfPlayer nameOfPlayer = GameObject.FindObjectOfType<NameOfPlayer>();

        playerTxt.text = PlayerPrefs.GetString("PlayerName");
        carColor = blue;
    }
    public void ShowIt()
    {
        
        if (EventSystem.current.currentSelectedGameObject.name == "Yellow")
        {
            cube.GetComponent<MeshRenderer>().material.color = yellow;
            carColor = yellow;
           
        }

        if(EventSystem.current.currentSelectedGameObject.name == "Red")
        {
            cube.GetComponent<MeshRenderer>().material.color = red;
            carColor = red;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "Blue")
        {
            cube.GetComponent<MeshRenderer>().material.color = blue;
            carColor = blue;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "Green")
        {
            cube.GetComponent<MeshRenderer>().material.color = green;
            carColor = green;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "White")
        {
            cube.GetComponent<MeshRenderer>().material.color = white;
            carColor = white;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            NextScene();
        }
    }
    public void NextScene()
    {
        SceneManager.LoadScene("SampleScene");
        
    }
}
