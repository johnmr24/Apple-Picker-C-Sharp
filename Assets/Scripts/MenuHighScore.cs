using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHighScore : MonoBehaviour
{
    public Text currentHighScore;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (PlayerPrefs.GetInt("CurrentScore") >= PlayerPrefs.GetInt("HighScore"))
                currentHighScore.text = "New High Score: " + PlayerPrefs.GetInt("HighScore");
            else
                currentHighScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        }
        else
            currentHighScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }
}
