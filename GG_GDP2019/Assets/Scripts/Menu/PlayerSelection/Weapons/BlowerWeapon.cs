using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Blower", menuName = "Weapons/Blower", order = 3)]
public class BlowerWeapon : AbstractWeapon
{
    [SerializeField]
    private float _power = 5f;

    public override void OnUseDown()
    {
        Debug.Log("Surprise ! Le joueur utilise un souffleur !");
    }
}
