using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Broom", menuName = "Weapons/Broom", order = 1)]
public class BroomWeapon : AbstractWeapon
{
    public override void OnUseDown()
    {
        Debug.Log("Le joueur appui sur un bouton en utilisant le balai.");
    }
}
