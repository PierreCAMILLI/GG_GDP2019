using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class MenuManager : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1")) {
            GameManager.Instance.NewGame();
        }
        
    }
}
