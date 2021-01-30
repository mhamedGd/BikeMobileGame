using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform player;
    public Vector3 offset;
    [Range(0, 10)]
    public float lerping_speed;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position != player.position + offset)
        {
            transform.position += ((player.position + offset) - transform.position) * lerping_speed * Time.fixedDeltaTime;
        }
        /*
        float rotateDegrees = Input.GetAxis("Horizontal") + Input.GetAxis("Vertical");
        transform.Rotate(Vector3.up * rotateDegrees);*/
    }
}
