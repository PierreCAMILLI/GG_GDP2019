﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choixPerso : MonoBehaviour
{
    [SerializeField]
    public Image[] imagePerso;
    private Image img;
    public PlayerSelection playerSelec;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        img = imagePerso[playerSelec.Number];
    }
}
