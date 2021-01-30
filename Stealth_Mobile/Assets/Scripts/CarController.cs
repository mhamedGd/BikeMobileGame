using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    CarGeneral carGeneral;
    // Start is called before the first frame update
    void Start()
    {
        carGeneral = GetComponent<CarGeneral>();
    }

    // Update is called once per frame
    void Update()
    {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal") * yAxis;
        float brakes = Input.GetButtonDown("Jump") ? 1 : 0;

        carGeneral.SetInputs(yAxis, xAxis);
    }
}
