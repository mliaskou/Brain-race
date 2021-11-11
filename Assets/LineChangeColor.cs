
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class LineChangeColor : MonoBehaviour
{

    public Color red = Color.red;
    public Color blue = Color.blue;
    public Color green = Color.green;
    public Color yellow = Color.yellow;
    public Color white = Color.white;
    public Color black = Color.black;

    public GameObject carBody;
    public GameObject line;

    public LineRenderer rendererLine;
    int layermask = 1 << 8;
    private bool isCollided;

    public PointsScore pointScore;

    private Vector3[] positions = new Vector3[3];
    private Vector3[] pos;


    private void Start()
    {
        Renderer renderedBody = carBody.GetComponent<MeshRenderer>();
        Color bodyColor = renderedBody.material.color;
        Debug.Log("Item color is " + bodyColor);
  
        LineRenderer rendererLine = line.GetComponent<LineRenderer>();
        rendererLine.startColor = bodyColor;
        rendererLine.endColor = bodyColor;//colorGradient.SetKeys(new GradientColorKey[] { new GradientColorKey(bodyColor, 1.0f) },
                                          //new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 1.0f) });
        
    }

    private void FixedUpdate()
    {

        SetPositionsLineRenderer();
    }


    void SetPositionsLineRenderer()
    {
        Renderer renderedBody = carBody.GetComponent<MeshRenderer>();
        Color bodyColor = renderedBody.material.color;
        for (int i = 0; i < rendererLine.positionCount - 1; i++)
        {
            Debug.Log("Position " + i + " is " + rendererLine.GetPosition(i));
            Debug.Log("Position " + (i + 1) + " is " + rendererLine.GetPosition(i + 1));
            if (Physics.Linecast(rendererLine.GetPosition(i), rendererLine.GetPosition(i + 1), layermask))
            {
                isCollided = true;
                Debug.DrawLine(rendererLine.GetPosition(i), rendererLine.GetPosition(i + 1), Color.white, 2.5f);
            }
        }
        if (isCollided == true)
        {
            pointScore.IncreaseScore();
            rendererLine.startColor = bodyColor;
            rendererLine.endColor = bodyColor;
            isCollided = false;

        }
        else if (isCollided == false)
        {
            pointScore.DecreaseScore();
            rendererLine.startColor = Color.black;
            rendererLine.endColor = Color.black;
        }
    }

    public float LengthOfLine()
    {

        float length = 0;
        for (int i =0; i<rendererLine.positionCount-1; i++)
        {
            length += Vector3.Distance(rendererLine.GetPosition(i + 1), rendererLine.GetPosition(i));

        }
        return length;
    }
}
