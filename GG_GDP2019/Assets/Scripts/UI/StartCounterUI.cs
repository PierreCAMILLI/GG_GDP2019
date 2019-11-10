using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class StartCounterUI : MonoBehaviour
{    
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndAnimation()
    {
        GameManager.Instance.StartGame();
        gameObject.SetActive(false);
    }
}
