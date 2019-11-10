using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Spot_lamp : MonoBehaviour
{
    private Spotlight spotlight;
    // Start is called before the first frame update
    void Start()
    {
        spotlight = GetComponentInParent<Spotlight>();

    }

    // Update is called once per frame
    void Update()
    {
        Light light = GetComponent<Light>();
        CapsuleCollider collider = GetComponentInParent<CapsuleCollider>();
        transform.position = new Vector3(transform.position.x, 1.3f * collider.radius / Mathf.Tan(light.spotAngle/2f * Mathf.PI / 180f), transform.position.z);

        Color colorr = Color.red;
        Color colorw = Color.white;
        light.color = Color.Lerp(colorw, colorr, spotlight.timeDetectingWaste/spotlight.thresholdTime);
    }


}
