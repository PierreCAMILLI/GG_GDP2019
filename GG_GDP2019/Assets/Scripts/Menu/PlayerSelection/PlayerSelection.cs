﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelection : MonoBehaviour
{

    public int Number = 0;
    public int SelectedObject = 0;

    public WeaponDisplay WeaponDisplay;
    public PersoDisplay PersoDisplay;

    [SerializeField]
    public Image[] ImagesAColorer;

    //delegate
    public delegate void OnTryLaunchGame();
    //event  
    public static event OnTryLaunchGame tryLaunch;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void PersoSuivant()
    {
        WeaponDisplay.ChangeWeapon(1);
        PersoDisplay.ChangePerso(1);
    }
    public void PersoPrecedent()
    {
        WeaponDisplay.ChangeWeapon(-1);
        PersoDisplay.ChangePerso(-1);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Image img in ImagesAColorer)
        {
            img.color = CommonProperties.Instance._colors[Number];
        }
    }

    public void TryLaunchGame()
    {
        tryLaunch();
    }
}
