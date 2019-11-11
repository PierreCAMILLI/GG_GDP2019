using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLevelText : MonoBehaviour
{
    [SerializeField]
    private Text levelText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "LVL:" + GameManager.Instance.level;
    }
}
