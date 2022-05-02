using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameController : MonoBehaviour
{
    public InputField textBox;
    public void ClickButton()
    {

        Player.Instance.setPlayerName(textBox.text);

        Debug.Log("Your name is: " + Player.Instance.getPlayerName());
    }
}
