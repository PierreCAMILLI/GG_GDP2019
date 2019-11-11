using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumSound : MonoBehaviour
{
    public AudioClip Sound;
    public AudioSource source;
    public bool VacuumUsed;

    // Start is called before the first frame update
    void Start()
    {
        VacuumUsed = false;
    }
    public void PlaySound()
    {
        source.clip = Sound;
        source.Play();
        source.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!VacuumUsed)
        {
            source.Stop();
            source.loop = false;
        }
    }
}
