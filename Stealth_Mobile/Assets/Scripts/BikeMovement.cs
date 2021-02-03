using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class BikeMovement : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    [HideInInspector] public float y_value;
    public GameObject[] frames;
    float cycle = 0;
    public GameObject explosion;
    Animator animator;
    AudioSource cycle_sound;
    public AudioClip cycling;
    public AudioClip gliding;
    AudioSource bell;
    bool bell_ready = true;

    
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        cycle_sound = GetComponent<AudioSource>();
        bell = transform.Find("Bell").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cycle > 1)
        {
            cycle = 0;
        }

        if (rb.velocity.magnitude > 8)
        {
            animator.SetBool("Fast", true);
        }
        else
        {
            animator.SetBool("Fast", false);

        }
        
        if (Input.GetButtonDown("Jump"))
        {
            Cycle();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            CycleBackwards();
        }
        cycle_sound.volume = Mathf.Clamp(cycle_sound.volume, 0f, 0.1f);
        transform.Rotate(Vector3.up * y_value);
        //rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -20, 20), Mathf.Clamp(rb.velocity.y, -20, 20), Mathf.Clamp(rb.velocity.z, -20, 20));
        if(rb.velocity.x != 0 || rb.velocity.z != 0)
        {
            cycle_sound.volume += 0.001f;
        }
        else
        {
            cycle_sound.volume -= 0.02f;
        }
        //Debug.Log(rb.velocity.magnitude);
    }

    public void Cycle()
    {
        animator.SetFloat("Cycle", cycle);
        rb.velocity += speed * transform.forward.normalized;
        cycle += 1;
    
    }

    public void CycleBackwards()
    {
        rb.velocity -= speed * transform.forward.normalized / 3;
    }

    public void BellRing()
    {
        if (bell_ready)
        {
            bell.Play();
            bell_ready = false;
        }
        else
        {
            Timer.Create( () => {
                bell_ready = true;
            }, 3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Vehicle" || other.tag == "Missile")
        {
            
            GameObject aftermath = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(aftermath, 5);
            Destroy(gameObject);
            
        }
    }
}
