﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarNavigation : MonoBehaviour
{

    Transform player;
    CarGeneral carGeneral;
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

    }
}
