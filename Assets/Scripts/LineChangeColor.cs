
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
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

    
    public AudioClip lineClip;
    public AudioSource lineSound;
    public AudioClip audioIn;
    public AudioClip audioOut;

    public AudioSource engineVolumeMusic;

    private bool soundPlayed =false;
    private void Start()
    {
        Renderer renderedBody = carBody.GetComponent<MeshRenderer>();
        Color bodyColor = renderedBody.material.color;
        Debug.Log("Item color is " + bodyColor);
  
        LineRenderer rendererLine = line.GetComponent<LineRenderer>();
        rendererLine.startColor = bodyColor;
        rendererLine.endColor = bodyColor;//colorGradient.SetKeys(new GradientColorKey[] { new GradientColorKey(bodyColor, 1.0f) },
                                          //new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 1.0f) });
                                          //notCollisionMusic.enabled = false
        
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
            //Debug.Log("Position " + i + " is " + rendererLine.GetPosition(i));
            //Debug.Log("Position " + (i + 1) + " is " + rendererLine.GetPosition(i + 1));
            if (Physics.Linecast(rendererLine.GetPosition(i), rendererLine.GetPosition(i + 1), layermask))
            {
                isCollided = true;
                Debug.DrawLine(rendererLine.GetPosition(i), rendererLine.GetPosition(i + 1), Color.white, 2.5f); // Create line from one point to other
            }
        }
        if (isCollided == true)
        {
            pointScore.IncreaseScore();
            engineVolumeMusic.volume = 0.25f;
            if(!soundPlayed)
            {

                if (!lineSound.isPlaying)// sound play if enters the line
                {
                    
                    lineSound.PlayOneShot(audioIn);
                    soundPlayed = true;

                }
            }
           
            
            rendererLine.startColor = bodyColor; // the color of the line is the color that you chose in previous scene
            rendererLine.endColor = bodyColor;
            isCollided = false;
           

            //notCollisionMusic.enabled = false;

        }
        else if (isCollided == false)
        {
            StartCoroutine(DecreaseVolume());
            if (soundPlayed)
            {
                if (!lineSound.isPlaying)// sound play if enters the line
                {
                    lineSound.PlayOneShot(audioOut);
                    soundPlayed = false;
                }
            }
            ;
            rendererLine.startColor = Color.black;
            rendererLine.endColor = Color.black;
            //notCollisionMusic.enabled = true;
            
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


    IEnumerator DecreaseVolume()
    {
        yield return new WaitForSeconds(3f);
        engineVolumeMusic.volume = 0.5f;
    }
}
