using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDriver : MonoBehaviour
{
    public float speed = 5000;
    public float brakingForce = 1000;
    public float steerAngle = 45;

    public WheelCollider frWheel;
    public WheelCollider flWheel;
    public WheelCollider brWheel;
    public WheelCollider blWheel;

    public TrailRenderer[] tireTracks;
    public ParticleSystem[] tireSmokes;

    float forwardTorque = 0;
    float steerTorque = 0;
    float brakesWeight = 0;

    [SerializeField] bool brake = false;

    Rigidbody rb;

    AudioSource source;
    public AudioClip carMoving;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        frWheel.motorTorque = speed * forwardTorque;
        flWheel.motorTorque = speed * forwardTorque;
        frWheel.steerAngle = steerAngle * steerTorque;
        flWheel.steerAngle = steerAngle * steerTorque;
        frWheel.brakeTorque = brakingForce * brakesWeight;
        flWheel.brakeTorque = brakingForce * brakesWeight;
        brWheel.brakeTorque = brakingForce * brakesWeight;
        blWheel.brakeTorque = brakingForce * brakesWeight;

        if(rb.velocity.magnitude > 5 && source.isPlaying == false)
        {
            source.PlayOneShot(carMoving);
            
        }
        else
        {
            source.Stop();
        }

        if(rb.velocity.magnitude > 20 && steerTorque != 0)
        {
            tireTracks[0].emitting = true;
            tireTracks[1].emitting = true;
            tireTracks[2].emitting = true;
            tireTracks[3].emitting = true;

            tireSmokes[0].Play();
            tireSmokes[1].Play();
            tireSmokes[2].Play();
            tireSmokes[3].Play();
        }
        else
        {
            tireTracks[0].emitting = false;
            tireTracks[1].emitting = false;
            tireTracks[2].emitting = false;
            tireTracks[3].emitting = false;

            tireSmokes[0].Stop();
            tireSmokes[1].Stop();
            tireSmokes[2].Stop();
            tireSmokes[3].Stop();
        }

    }

    public void SetInputs(float _forwardTorque, float _steerTorque)
    {
        forwardTorque = _forwardTorque;
        steerTorque = _steerTorque;
    }
    public void SetBrakes(float _brakesWeight)
    {
        brakesWeight = _brakesWeight;
    }
}
