using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{

    public int Number = 0;
    public bool Selected = false;
    public bool Connected = false;
    public int SelectedObject = 0;

    public WeaponDisplay WeaponDisplay;
    public PersoDisplay PersoDisplay;

    // Start is called before the first frame update
    void Start()
    {
        WeaponDisplay = GetComponent<WeaponDisplay>();
        PersoDisplay = GetComponent<PersoDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Controls.GetPlayer(Number).LeftDown())
        //{
        //    WeaponDisplay.ChangeWeapon(-1);
        //    PersoDisplay.ChangePerso(-1);
        //}
        //else if (Controls.GetPlayer(Number).Instance.RightDown())
        //{
        //    WeaponDisplay.ChangeWeapon(1);
        //    PersoDisplay.ChangePerso(1);
        //}

    }
}
