using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Spot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Light light = GetComponent<Light>();
        CapsuleCollider collider = GetComponentInParent<CapsuleCollider>();
        transform.position = new Vector3(transform.position.x, collider.radius / Mathf.Tan(light.spotAngle/2f * Mathf.PI / 180f), transform.position.z);
    }


}
