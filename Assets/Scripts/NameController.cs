using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameController : MonoBehaviour
{
    public InputField textBox;
    public void ClickButton()// Take the name of the player that is assigned
    {

        Player.Instance.setPlayerName(textBox.text);

        Debug.Log("Your name is: " + Player.Instance.getPlayerName());
    }

    private void Update()
    {
        Player.Instance.setPlayerName(textBox.text);

        Debug.Log("Your name is: " + Player.Instance.getPlayerName());
    }
}
