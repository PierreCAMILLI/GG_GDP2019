using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnGameOver : MonoBehaviour
{

    private bool once = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.IsState("GameOver") && !once)
        {
            once = true;
            transform.GetComponent<AudioSource>().Play();
        }
            
    }
}
