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
        VacuumSound v = vacuum.GetComponent<VacuumSound>();
        v.VacuumUsed = true;

    }

    public override void OnUseUp(Hero hero)
    {
        Transform vacuum = hero.gameObject.transform.Find("perso2").Find("vacuum").Find("vacuumActivable");
        vacuum.gameObject.SetActive(false);
        VacuumSound v = vacuum.GetComponent<VacuumSound>();
        v.VacuumUsed = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
