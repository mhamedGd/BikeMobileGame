using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesManager : MonoBehaviour
{
    public int waves;
    public Text wavesUI;
    public Shooter shooter;
    public Spawner spawner;
    float timer = 20;
    public float currentTimer;
    // Start is called before the first frame update
    void Start()
    {
        currentTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        wavesUI.text = waves.ToString();
        if(currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
            return;
        }
        
        waves += 1;
        spawner.numberOfSpawns = waves;
        shooter.missilesToShoot = waves;

        currentTimer = timer;
    }
}
