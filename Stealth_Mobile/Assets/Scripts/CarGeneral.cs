using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGeneral : MonoBehaviour
{
    public float speed;
    public float turnSpeed;

    Rigidbody sphere;
    public float offset;

    float zAxis = 0;
    float xAxis = 0;

    public TrailRenderer[] tracks;
    public ParticleSystem[] smoke;

    // Start is called before the first frame update
    void Start()
    {
        sphere = transform.Find("Sphere").GetComponent<Rigidbody>();
        sphere.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = sphere.transform.position + (Vector3.up * offset);
        transform.Rotate(0, xAxis * turnSpeed * Time.deltaTime, 0, Space.World);

        if(sphere.velocity.magnitude > 35 && xAxis != 0)
        {
            for(int i = 0; i < tracks.Length; i++)
            {
                tracks[i].emitting = true;
                
            }
            smoke[0].Play();
            smoke[1].Play();
        }
        else
        {
            for (int i = 0; i < tracks.Length; i++)
            {
                tracks[i].emitting = false;
                //smoke[i].Stop();
            }
        }
    }

    private void FixedUpdate()
    {
        sphere.AddForce(transform.forward * zAxis * speed, ForceMode.Acceleration);
        
    }

    public void SetInputs(float _zAxis, float _xAxis)
    {
        zAxis = _zAxis;
        xAxis = _xAxis;
    }
}
