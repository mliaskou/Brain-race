using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic Instance;
    private void Awake()// Singleton pattern to keep the sound from the first scene and delete it if there is already a copy.
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

    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene(); //Take the name of the current scene
        if (scene.name == "StartScene" || scene.name == "SampleScene")
        {
            this.GetComponent<AudioSource>().Stop();// stop the audio

        }
        else if(!this.GetComponent<AudioSource>().isPlaying)
        {
            this.GetComponent<AudioSource>().Play();// else play
        }

       
    }
}
