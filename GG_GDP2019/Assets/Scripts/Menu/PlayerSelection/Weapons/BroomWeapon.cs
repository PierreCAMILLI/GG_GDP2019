using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Broom", menuName = "Weapons/Broom", order = 1)]
public class BroomWeapon : AbstractWeapon
{
    [SerializeField]
    private GameObject broom;

    [SerializeField]
    private Vector3 broomPosition;
    

    private GameObject broomInstance;
    public override void OnAwake(Hero hero) {
    }
    public override void OnUseDown(Hero hero)
    {
        hero.Animator.SetBool("BroomDown", true);
    }

    public override void OnUseUp(Hero hero)
    {
        hero.Animator.SetBool("BroomDown", false);
    }
}
