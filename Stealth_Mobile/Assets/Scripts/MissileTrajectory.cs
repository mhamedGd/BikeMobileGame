using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTrajectory : MonoBehaviour
{

    Transform player;
    Rigidbody rb;

    public GameObject afterMath;
    public float speed;
    float offset;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<BikeMovement>().transform;
        rb = GetComponent<Rigidbody>();
        offset = Random.Range(-4f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 direction = player.position - transform.position + (Vector3.up * 0.15f);
        transform.forward = direction + Vector3.one * offset * (1 - offset);
        rb.velocity = transform.forward * speed;

        transform.forward = rb.velocity.normalized;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Missile" || other.tag != "Vehicle")
        {
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            if (transform.Find("MissileShape"))
            {
                Destroy(transform.Find("MissileShape").gameObject);
            }
            GetComponentInChildren<ParticleSystem>().Stop();
            GameObject am = Instantiate(afterMath, transform.position, Quaternion.identity);
            Destroy(am, 10);
            Destroy(gameObject, 2);
        }        
    }
}
