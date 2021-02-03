using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public float cameraShakeIntensity;
    public float shakeDuration;
    float shakeDurationCurrent;
    bool shake = false;
    Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (shake)
        {
            if(shakeDuration > 0)
            {
                shakeDurationCurrent -= Time.deltaTime;
                transform.position += Random.insideUnitSphere * cameraShakeIntensity * Time.deltaTime;
                return;
            }

            
            
            
        }
    }

    void Shake(float _shakeIntensity, float _shakeDuration)
    {
        cameraShakeIntensity = _shakeIntensity;
        shakeDuration = _shakeDuration;
        shake = true;
    }
}
