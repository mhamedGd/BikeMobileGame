using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public GameObject missile;
    public float missilesToShoot = 1;
    public float timer = 2;
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = timer;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime > 0)
        {
            return;
        }
        currentTime = timer;
        StartCoroutine("Shoot");
    }

    IEnumerator Shoot()
    {
        for (int i = 0; i < missilesToShoot; i++)
        {
            Instantiate(missile, transform.position + (Vector3.one * Random.Range(-20, 20)), missile.transform.rotation);

            yield return new WaitForEndOfFrame();
        }
    }
}
