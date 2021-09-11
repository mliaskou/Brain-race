using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
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

    
    public static bool Color1;
    public static bool Color2;
    public static bool Color3;
    public static bool Color4;
    public static bool Color5;

    public GameObject line;
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


    public void ShowIt()
    {
        
        if (EventSystem.current.currentSelectedGameObject.name == "Yellow")
        {
            cube.GetComponent<MeshRenderer>().material.color = yellow;
            line.GetComponent<Renderer>().sharedMaterial.color = yellow;
            Color1 = true;
           
        }

        if(EventSystem.current.currentSelectedGameObject.name == "Red")
        {
            cube.GetComponent<MeshRenderer>().material.color = red;
            Color2 = true;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "Blue")
        {
            cube.GetComponent<MeshRenderer>().material.color = blue;
            Color3 = true;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "Green")
        {
            cube.GetComponent<MeshRenderer>().material.color = green;
            Color4 = true;
        }
        if (EventSystem.current.currentSelectedGameObject.name == "White")
        {
            cube.GetComponent<MeshRenderer>().material.color = white;
            Color5 = true;
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene("SampleScene");
        
    }
}
