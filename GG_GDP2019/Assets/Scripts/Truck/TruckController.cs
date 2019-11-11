using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if(gameObject.transform.position.z >= 3){
        //     gameObject.SetActive(false);
        // }
        transform.Translate(-Time.deltaTime, 0, 0);
    }
}
