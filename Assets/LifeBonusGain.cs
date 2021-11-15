using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBonusGain : MonoBehaviour
{
    public LifePanelAdd lifepanelAdd;
    private int lives = 0;
    public int number = 1;

    private void Start()
    {
         
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            lives++;
            lifepanelAdd.Slots[number - 1].SetActive(true);
            Destroy(gameObject);
        }
    }
}
