using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SteeringButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float direction;
    public float steering_speed;
    public BikeMovement bike;
    public void OnPointerDown(PointerEventData p)
    {
        if (bike.GetComponent<Rigidbody>().velocity.magnitude > 5)
        {
            bike.y_value += Time.deltaTime * direction * steering_speed;
        }
        if (bike.GetComponent<Rigidbody>().velocity.magnitude > 12)
        {

            bike.transform.Find("TiresTrail 01").GetComponent<TrailRenderer>().emitting = true;
            bike.transform.Find("TiresTrail 02").GetComponent<TrailRenderer>().emitting = true;
            bike.transform.Find("Smoke").GetComponent<ParticleSystem>().Play();
            bike.GetComponent<AudioSource>().clip = bike.GetComponent<BikeMovement>().gliding;
            bike.GetComponent<AudioSource>().Play();
        }
    }

    public void OnPointerUp(PointerEventData p)
    {
        bike.y_value = 0;
        StopTiresTrails();
    }

    void StopTiresTrails()
    {
        bike.transform.Find("TiresTrail 01").GetComponent<TrailRenderer>().emitting = false;
        bike.transform.Find("TiresTrail 02").GetComponent<TrailRenderer>().emitting = false;
        bike.transform.Find("Smoke").GetComponent<ParticleSystem>().Stop();
        bike.GetComponent<AudioSource>().clip = bike.GetComponent<BikeMovement>().cycling;
        bike.GetComponent<AudioSource>().Play();
    }
}
