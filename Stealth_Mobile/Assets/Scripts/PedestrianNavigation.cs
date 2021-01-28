using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PedestrianNavigation : MonoBehaviour
{

    Rigidbody rb;

    [HideInInspector]
    public bool reachedDestination = false;
    public Vector3 destination;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = speed * Random.Range(0.1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(destination, transform.position) < 0.2f)
        {
            reachedDestination = true;
        }
    }

    public void MoveTo(Vector3 _destination)
    {
        destination = _destination;
        Vector3 direction = (destination - transform.position);
        rb.velocity = direction.normalized * speed;
        transform.forward = new Vector3(direction.x, 0, direction.z);
    }
}
