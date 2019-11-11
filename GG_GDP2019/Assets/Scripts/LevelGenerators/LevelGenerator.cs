using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        GameManager.Instance.difficulty += 200f;
        GameManager.Instance.level += 1;
        float difficultyPerGenerator = GameManager.Instance.difficulty / transform.childCount;
        foreach (Transform child in transform)
        {
            child.GetComponent<Generator>().Generate(difficultyPerGenerator);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
