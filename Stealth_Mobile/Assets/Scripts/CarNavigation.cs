using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarNavigation : MonoBehaviour
{



    Transform player;
    CarGeneral carGeneral;
    public float distanceMultiplier = 1;
    public float distanceComparison = 20;
    public GameObject explosion;
    float zAxis = 0;
    float xAxis = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        carGeneral = GetComponent<CarGeneral>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diretionNotNormalized = player.position - transform.position;
        float dot = Vector3.Dot(transform.forward, diretionNotNormalized.normalized);
        float dotRight = Vector3.Dot(transform.right, diretionNotNormalized.normalized);



        xAxis = dotRight < 0 ? -1 : 1;

        if (Vector3.Distance(player.position, transform.position) > 20)
        {
            zAxis = dot < 0 ? -1 : 1;
        }
        else
        {
            zAxis = dot < 0 ? -1 : 1;
            zAxis *= distanceMultiplier;

        }
        carGeneral.SetInputs(zAxis, dotRight);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Sphere" || other.tag != "Ground")
        {
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(gameObject);
        }
    }
}
