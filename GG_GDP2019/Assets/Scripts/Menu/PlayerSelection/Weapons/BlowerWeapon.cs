using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Blower", menuName = "Weapons/Blower", order = 2)]
public class BlowerWeapon : AbstractWeapon
{
    [SerializeField]
    private float _power = 5f;

    public override void OnUseDown(Hero hero)
    {
        Debug.Log("Surprise ! Le joueur utilise un souffleur !");
    }
}
