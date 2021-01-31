using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float numberOfSpawns;
    public GameObject spawn;
    public Transform[] spawnPoints;
    CarGeneral[] spawns;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        spawns = FindObjectsOfType<CarGeneral>();
        if (spawns.Length <= 0)
        {
            for(int i = 0; i <= numberOfSpawns; i++)
            {
                StartCoroutine("DelaySpawn", i);
            }
        }
    }

    IEnumerator DelaySpawn(int i)
    {
        Instantiate(spawn, spawnPoints[i].position, spawnPoints[i].rotation);

        yield return new WaitForSeconds(0.3f);
    }
}
