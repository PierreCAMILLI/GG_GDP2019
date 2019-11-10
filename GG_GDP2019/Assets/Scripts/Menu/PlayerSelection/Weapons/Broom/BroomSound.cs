using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomSound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip sound;
    public GameObject perso;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = perso.GetComponent<Animator>();
    }
    public void PlaySound()
    {
        source.clip = sound;
        source.Play();
        source.loop = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying && anim.GetBool("BroomDown"))
        {
            PlaySound();
        }
        if (!anim.GetBool("BroomDown"))
        {
            source.Stop();
            source.loop = false;
        }
    }
}
