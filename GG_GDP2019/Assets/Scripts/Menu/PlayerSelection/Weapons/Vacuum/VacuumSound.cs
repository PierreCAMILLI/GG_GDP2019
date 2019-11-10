using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumSound : MonoBehaviour
{
    public AudioSource mySound;
    public bool VacuumUsed;

    // Start is called before the first frame update
    void Start()
    {
        VacuumUsed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (VacuumUsed)
        {
            mySound.enabled = true;
            mySound.loop = true;
        }
        else
        {
            mySound.enabled = false;
            mySound.loop = false;
        }
    }
}
