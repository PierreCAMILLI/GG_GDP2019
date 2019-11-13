using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float difficultyPerGenerator = 0f;
            difficultyPerGenerator = GameManager.Instance.difficulty;
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
