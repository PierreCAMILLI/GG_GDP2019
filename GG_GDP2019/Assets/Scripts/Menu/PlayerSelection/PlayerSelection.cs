using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        WeaponDisplay.GetComponent<Image>().color = CommonProperties.Instance._colors[Number];
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

    }
}
