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
        Transform vacuum = hero.gameObject.transform.Find("vacuum");
        //vacuum.gameObject.SetActive(true);
    }

    public override void OnUseUp(Hero hero)
    {
        Transform vacuum = hero.gameObject.transform.Find("vacuum");
        //vacuum.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
