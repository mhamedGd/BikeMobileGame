using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed;
    public bl_Joystick movement_joystick;

    Rigidbody rb;
    Vector3 movement_direction;
    Vector3 last_direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {       
        movement_direction.x = movement_joystick.Horizontal;
        movement_direction.z = movement_joystick.Vertical;
     
        if (movement_direction.x != 0)
        {
            last_direction.x = movement_direction.x;
        }
        if (movement_direction.z != 0)
        {
            last_direction.z = movement_direction.z;
        }

        Debug.Log(last_direction);

        if(last_direction.magnitude != 0)
        {
            transform.forward = -last_direction.normalized;
        }
        
        rb.velocity = movement_direction.normalized * -speed + Vector3.up * rb.velocity.y;

    }
}
