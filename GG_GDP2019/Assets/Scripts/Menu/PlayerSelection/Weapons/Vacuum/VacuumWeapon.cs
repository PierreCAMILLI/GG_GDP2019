using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Vacuum", menuName = "Weapons/Vacuum", order = 2)]
public class VacuumWeapon : AbstractWeapon
{

    [SerializeField]
    private float _power = 5f;


    // Start is called before the first frame update
    void Start()
    {
    }
    public override void OnUseDown(Hero hero)
    {
        Transform vacuum = hero.gameObject.transform.Find("perso").Find("vacuum").Find("vacuumActivable");
        vacuum.gameObject.SetActive(true);
        Transform v = hero.gameObject.transform.Find("perso").Find("vacuum");
        VacuumSound vs = v.GetComponent<VacuumSound>();
        vs.PlaySound();
        vs.VacuumUsed = true;
    }

    public override void OnUseUp(Hero hero)
    {
        Transform vacuum = hero.gameObject.transform.Find("perso").Find("vacuum").Find("vacuumActivable");
        vacuum.gameObject.SetActive(false);
        Transform v = hero.gameObject.transform.Find("perso").Find("vacuum");
        VacuumSound vs = v.GetComponent<VacuumSound>();
        vs.VacuumUsed = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
