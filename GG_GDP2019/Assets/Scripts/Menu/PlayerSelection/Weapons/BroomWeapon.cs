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
        Transform broom = hero.transform.Find("Broom");
        Transform broomCollider = broom.Find("broomCollider");
        broomCollider.gameObject.SetActive(true);
        broom.localRotation = Quaternion.Euler(-3, 0, 0);
    }

    public override void OnUseUp(Hero hero)
    {
        Transform broom = hero.transform.Find("Broom");
        Transform broomCollider = broom.Find("broomCollider");
        broomCollider.gameObject.SetActive(false);
        broom.localRotation = Quaternion.Euler(-35, 0, 0);
    }
}
