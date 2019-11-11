using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        GameManager.Instance.difficulty += 100f * GameManager.Instance.playerSelection.Length * 1f / 3f + 66.333333f;
        GameManager.Instance.level += 1;
        float difficultyPerGenerator = GameManager.Instance.difficulty;
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
