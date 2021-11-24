using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePanelAdd : MonoBehaviour
{
    public static LifePanelAdd Instance;
    public GameObject[] Slots;

   

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
    


   


}
