using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float numberOfSpawns;
    public GameObject spawn;
    public Transform[] spawnPoints;
    CarGeneral[] spawns;
    public GameObject[] buildings;
    public float numberOfBuildings;
    public Transform ground;

    HighScoreManager highScoreManager;
    // Start is called before the first frame update
    void Start()
    {
        highScoreManager = FindObjectOfType<HighScoreManager>();
        numberOfBuildings = Random.Range(0, 16);
        for (int i = 0; i <= numberOfBuildings; i++)
        {
            Instantiate(buildings[Random.Range(0, buildings.Length)], new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)), Quaternion.EulerAngles(0, Random.Range(0, 360), 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawns = FindObjectsOfType<CarGeneral>();
        if (highScoreManager.canStart)
        {
            if (spawns.Length <= 0)
            {
                for (int i = 0; i <= numberOfSpawns; i++)
                {
                    StartCoroutine("DelaySpawn", i);
                }
            }
        }

        
    }

    IEnumerator DelaySpawn(int i)
    {
        Instantiate(spawn, spawnPoints[i].position, spawnPoints[i].rotation);

        yield return new WaitForSeconds(0.3f);
    }
}
