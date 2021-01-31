using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public GameObject missile;
    public float missilesToShoot = 0;
    public float timer = 2;
    float currentTime;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = timer;
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
        transform.Rotate(Vector3.up, Vector3.Angle(transform.position, player.position));
        StartCoroutine("Shoot");
    }

    IEnumerator Shoot()
    {
        for (int i = 0; i < missilesToShoot; i++)
        {
            GameObject missileInstance = Instantiate(missile, transform.position + (Vector3.one * Random.Range(-20, 20)), missile.transform.rotation);
           // missileInstance.GetComponent<Rigidbody>().AddForce(GetForce() * missile.transform.forward, ForceMode.VelocityChange);

            yield return new WaitForEndOfFrame();
        }
    }

    float GetForce()
    {
        float distance = Vector3.Distance(player.position, transform.position)/2;
        float acceleration = (2 * Mathf.Sqrt(100 + (distance * distance))) / (Time.deltaTime * Time.deltaTime);
        return acceleration * 10;
    }
}
