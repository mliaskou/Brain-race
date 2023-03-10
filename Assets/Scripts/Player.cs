using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    private static Color carColor = Color.blue;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void SetCarColor(Color color)
    {
       carColor = color;
    }

    public Color GetCarColor()
    {
        return carColor;
    }


    public void setPlayerName(string name)

    {
        PlayerPrefs.SetString("PlayerName", name); // Save player name
    }

    public string getPlayerName()
    {
        return PlayerPrefs.GetString("PlayerName", "");// Get player name
    }

    public void setPlayerScore(int score)
    {
        PlayerPrefs.SetInt("PlayerScore", score);
    }

    public int getPlayerScore()
    {
        return PlayerPrefs.GetInt("PlayerScore", 0);
    }
}
