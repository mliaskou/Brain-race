using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBonusGain : MonoBehaviour
{
    
    public bool activateInactive;
    public LifePanelAdd lifePanelAdd;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Heart")
        {
            for (int i = 0; i <lifePanelAdd.Slots.Length; i++)
            {
                if (lifePanelAdd.Slots[i].activeSelf == false)
                {
                    lifePanelAdd.Slots[i].SetActive(true);
                    break;
                }
            }

            Destroy(other.gameObject);

        }
    }

}
