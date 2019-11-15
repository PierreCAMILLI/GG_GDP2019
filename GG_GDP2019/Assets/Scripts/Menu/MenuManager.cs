using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using System;

public class MenuManager : MonoBehaviour
{
    //Gestion du changement de scene intra MenuScene
    private int SceneName;
    private const int START_SCENE = 0;
    private const int SELECT_SCENE = 1;
    private const int CREDITS_SCENE = 2;
    private const int INSTRUCTIONS_SCENE = 3;
    public GameObject BlocSelection;
    public GameObject BlocStart;
    public GameObject BlocCredits;
    public GameObject BlocInstructions;
    private InputDevice inputDevice;
    public boutonSelect startTexte;
    public boutonSelect creditsTexte;
    public boutonSelect quitterTexte;

    private int SurQuelBouton;
    private const int SUR_START = 0;
    private const int SUR_CREDITS = 1;
    private const int SUR_QUITTER = 2;

    public PlayersSelectionManager playerSelectionManager;

    void Start()
    {
        SceneName = START_SCENE;
        BlocSelection.SetActive(false);
        BlocCredits.SetActive(false);
        BlocInstructions.SetActive(false);
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
                else if (SurQuelBouton == SUR_QUITTER)
                {
                    Application.Quit();
                }
            }
            else if (inputDevice.Direction.WasPressed && inputDevice.Direction.Y != 0)
            {
                if (inputDevice.Direction.Y < 0)
                    SurQuelBouton++;
                else
                    SurQuelBouton--;
               

                if (SurQuelBouton < 0)
                    SurQuelBouton = SUR_QUITTER;
                else if (SurQuelBouton > SUR_QUITTER)
                    SurQuelBouton = 0;

                if (SurQuelBouton == SUR_START)
                {
                    creditsTexte.GetComponent<Animator>().SetBool("selected", false);
                    startTexte.GetComponent<Animator>().SetBool("selected", true);
                    quitterTexte.GetComponent<Animator>().SetBool("selected", false);
                }
                else if (SurQuelBouton == SUR_CREDITS)
                {
                    creditsTexte.GetComponent<Animator>().SetBool("selected", true);
                    startTexte.GetComponent<Animator>().SetBool("selected", false);
                    quitterTexte.GetComponent<Animator>().SetBool("selected", false);
                }
                else if (SurQuelBouton == SUR_QUITTER)
                {
                    creditsTexte.GetComponent<Animator>().SetBool("selected", false);
                    startTexte.GetComponent<Animator>().SetBool("selected", false);
                    quitterTexte.GetComponent<Animator>().SetBool("selected", true);
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
        else if (SceneName == SELECT_SCENE)
        {
            inputDevice = InputManager.ActiveDevice;
            if (inputDevice.Action2.WasPressed)
            {
                BlocCredits.SetActive(false);
                BlocSelection.SetActive(false);
                BlocStart.SetActive(true);
                playerSelectionManager.setSceneName(START_SCENE);
                playerSelectionManager.resetSelection();
                SceneName = START_SCENE;
                SurQuelBouton = SUR_START;
                creditsTexte.GetComponent<Animator>().SetBool("selected", false);
                startTexte.GetComponent<Animator>().SetBool("selected", true);
                quitterTexte.GetComponent<Animator>().SetBool("selected", false);
            }
        }
        else if (SceneName == INSTRUCTIONS_SCENE)
        {
            BlocSelection.SetActive(false);
            BlocInstructions.SetActive(true);
            playerSelectionManager.setSceneName(INSTRUCTIONS_SCENE);
        }
        if (SurQuelBouton == SUR_START)
        {
            creditsTexte.GetComponent<Animator>().SetBool("selected", false);
            startTexte.GetComponent<Animator>().SetBool("selected", true);
            quitterTexte.GetComponent<Animator>().SetBool("selected", false);
        }
        Debug.Log(SurQuelBouton);
    }
        public void launch()
        {
            GameManager.Instance.NewGame();
        }

    internal void launching()
    {
        SceneName = INSTRUCTIONS_SCENE;
        Invoke("launch", 5f);
    }
}
