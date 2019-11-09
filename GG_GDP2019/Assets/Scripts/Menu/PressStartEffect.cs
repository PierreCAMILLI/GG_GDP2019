using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressStartEffect : MonoBehaviour
{
    public float fadingMin;
    public float fadingMax;
    public float vitesseFading;
    private bool fadingUp;
    private float fading;


    // Start is called before the first frame update
    void Start()
    {
        fading = GetComponent<Image>().color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadingUp)
        {
            //GetComponent<Image>().color.a + vitesseFading;
        }   
    }
}
