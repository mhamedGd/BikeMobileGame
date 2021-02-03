using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{

    public Text highScoreText;
    public GameObject startScreen;
    WavesManager wavesManager;
    
    int highScore;


    public bool canStart = false;
    // Start is called before the first frame update
    void Start()
    {
        wavesManager = FindObjectOfType<WavesManager>();
        highScore = PlayerPrefs.GetInt("HighScore");
        if (wavesManager.waves > highScore)
        {
            highScore = wavesManager.waves;
        }
        PlayerPrefs.SetInt("HighScore", highScore);
        
        highScoreText.text = highScore.ToString();
    }

    private void Update()
    {
        if (wavesManager.waves > highScore)
        {
            highScore = wavesManager.waves;
        }
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    public void StartTheGame()
    {
        startScreen.SetActive(false);
        canStart = true;
    }
}
