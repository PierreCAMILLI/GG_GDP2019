using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelection : MonoBehaviour
{

    public int Number = 0;
    public int SelectedObject = 0;

    public bool present;
    public bool pret;

    public WeaponDisplay WeaponDisplay;
    public PersoDisplay PersoDisplay;

    [SerializeField]
    public Image[] ImagesAColorer;

    [SerializeField]
    public GameObject[] ImagesACacherSiJoueurNonPresent;
    
    [SerializeField]
    public GameObject[] ImagesACacherSiJoueurPresent;

    [SerializeField]
    public GameObject[] ImagesACacherSiJoueurPret;

    public Image imgPret;

    //delegate
    public delegate void OnTryLaunchGame();
    //event  
    public static event OnTryLaunchGame tryLaunch;

    // Start is called before the first frame update
    void Start()
    {
        
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
        foreach (Image img in ImagesAColorer)
        {
            img.color = CommonProperties.Instance._colors[Number];
        }
        if (present)
        {
            foreach (GameObject go in ImagesACacherSiJoueurNonPresent)
            {
                go.SetActive(true);
            }
            foreach (GameObject go in ImagesACacherSiJoueurPresent)
            {
                go.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject go in ImagesACacherSiJoueurNonPresent)
            {
                //Debug.Log(ImagesACacherSiJoueurNonPresent.Length);
                go.SetActive(false);
            }
        }
        if (pret)
        {
            foreach (GameObject go in ImagesACacherSiJoueurPret)
            {
                go.gameObject.SetActive(false);
            }
        }
    }

    public void TryLaunchGame()
    {
        tryLaunch();
    }
}
