using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour
{

    public Text highScoreText;
    public GameObject startScreen;
    WavesManager wavesManager;
    
    int highScore;


    public bool canStart = false;

    public AudioClip[] music;
    AudioSource source;

    public float timer;
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = timer;
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
        if (FindObjectOfType<BikeMovement>() == null)
        {
            if (currentTime <= 0)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                currentTime -= Time.deltaTime;
            }
        }
    }

    public void StartTheGame()
    {
        startScreen.SetActive(false);
        canStart = true;
        source = GetComponent<AudioSource>();
        source.clip = music[Random.Range(0, music.Length)];
        source.Play();
    }
}
