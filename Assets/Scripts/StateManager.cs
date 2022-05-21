using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public GameObject cube;
    public GameObject car;
    public Color red = Color.red;
    public Color blue = Color.blue;
    public Color green = Color.green;
    public Color yellow = Color.yellow;
    public Color white = Color.white;

    public GameObject prefab;
    
    public static Color carColor;

    public GameObject line;

    public Text playerTxt;

    public HandleScenes handleScenes;
  

    private void Start()
    {
        playerTxt.text = Player.Instance.getPlayerName();
        
    }
    public void ShowIt()
    {
        
        if (EventSystem.current.currentSelectedGameObject.name == "Yellow")
        {
            cube.GetComponent<MeshRenderer>().material.color = yellow;
            Player.Instance.SetCarColor(yellow);
        }

        if(EventSystem.current.currentSelectedGameObject.name == "Red")
        {
            cube.GetComponent<MeshRenderer>().material.color = red;
            Player.Instance.SetCarColor(red);
        }
        if (EventSystem.current.currentSelectedGameObject.name == "Blue")
        {
            cube.GetComponent<MeshRenderer>().material.color = blue;
            Player.Instance.SetCarColor(blue);
        }
        if (EventSystem.current.currentSelectedGameObject.name == "Green")
        {
            cube.GetComponent<MeshRenderer>().material.color = green;
            Player.Instance.SetCarColor(green);
        }
        if (EventSystem.current.currentSelectedGameObject.name == "White")
        {
            cube.GetComponent<MeshRenderer>().material.color = white;
            Player.Instance.SetCarColor(white);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            handleScenes.StartGame();
        }
    }
   
}
