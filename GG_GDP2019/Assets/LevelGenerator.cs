using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Generator>().Generate(1000f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
