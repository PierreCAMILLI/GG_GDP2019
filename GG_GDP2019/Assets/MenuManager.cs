using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class MenuManager : MonoBehaviour
{
    //Gestion du changement de scene intra MenuScene
    private int SceneName;
    private const int START_SCENE = 0;
    private const int SELECT_SCENE = 1;
    private const int CREDITS_SCENE = 2;
    public GameObject BlocSelection;
    public GameObject BlocStart;
    public GameObject BlocCredits;
    private InputDevice inputDevice;
    public boutonSelect startTexte;
    public boutonSelect creditsTexte;

    private int SurQuelBouton;
    private const int SUR_START = 0;
    private const int SUR_CREDITS = 1;

    public PlayersSelectionManager playerSelectionManager;

    void Start()
    {
        SceneName = START_SCENE;
        BlocSelection.SetActive(false);
        BlocCredits.SetActive(false);
        SurQuelBouton = SUR_START;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneName == START_SCENE)
        {
            inputDevice = InputManager.ActiveDevice;
            if (inputDevice.Action1.WasPressed)
            {
                if (SurQuelBouton == SUR_START)
                {
                    SceneName = SELECT_SCENE;
                    BlocCredits.SetActive(false);
                    BlocSelection.SetActive(true);
                    BlocStart.SetActive(false);
                    playerSelectionManager.setSceneName(SELECT_SCENE);
                }
                else if (SurQuelBouton == SUR_CREDITS)
                {
                    SceneName = CREDITS_SCENE;
                    BlocCredits.SetActive(true);
                    BlocSelection.SetActive(false);
                    BlocStart.SetActive(false);
                    playerSelectionManager.setSceneName(CREDITS_SCENE);
                }
            }
            else if (inputDevice.Direction.WasPressed && inputDevice.Direction.Y != 0)
            {
                if (SurQuelBouton == SUR_START)
                {
                    creditsTexte.GetComponent<Animator>().SetBool("selected", true);
                    startTexte.GetComponent<Animator>().SetBool("selected", false);
                    SurQuelBouton = SUR_CREDITS;
                }
                else if (SurQuelBouton == SUR_CREDITS)
                {
                    creditsTexte.GetComponent<Animator>().SetBool("selected", false);
                    startTexte.GetComponent<Animator>().SetBool("selected", true);
                    SurQuelBouton = SUR_START;
                }
            }
        }
        else if (SceneName == CREDITS_SCENE)
        {
            inputDevice = InputManager.ActiveDevice;
            if (inputDevice.Action1.WasPressed)
            {
                SceneName = START_SCENE;
                BlocSelection.SetActive(false);
                BlocCredits.SetActive(false);
                BlocStart.SetActive(true);
                SurQuelBouton = SUR_START;
            }
        }
        if (SurQuelBouton == SUR_START)
        {
            creditsTexte.GetComponent<Animator>().SetBool("selected", false);
            startTexte.GetComponent<Animator>().SetBool("selected", true);
        }
    }
}
