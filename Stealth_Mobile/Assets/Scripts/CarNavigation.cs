using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarNavigation : MonoBehaviour
{

    public float speed;
    public Transform currentWaypoint;
    public CarWaypoints carWaypoints;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //carWaypoints = FindObjectOfType<CarWaypoints>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector3.Distance(currentWaypoint.position, transform.position) <= 1.5f){
            currentWaypoint = carWaypoints.NextWaypoint(currentWaypoint);
        }
        Vector3 direction = (currentWaypoint.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg - 90;

        transform.eulerAngles = Vector3.up * -angle;
        rb.velocity = transform.forward * speed;
    }

    public void SetCurrentWaypoint(Transform current_waypoint)
    {
        currentWaypoint = current_waypoint;
        Debug.Log("Waypoint " + currentWaypoint.name + " has been set as waypoint");
    }
}
