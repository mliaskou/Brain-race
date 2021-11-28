using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBonusGain : MonoBehaviour
{
    
    
    public LifePanelAdd lifePanelAdd;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Heart"))
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
