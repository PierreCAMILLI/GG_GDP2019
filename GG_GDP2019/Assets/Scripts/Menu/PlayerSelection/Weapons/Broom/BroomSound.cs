using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomSound : MonoBehaviour
{
    public AudioSource mySound;
    public GameObject perso;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = perso.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("BroomDown"))
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
