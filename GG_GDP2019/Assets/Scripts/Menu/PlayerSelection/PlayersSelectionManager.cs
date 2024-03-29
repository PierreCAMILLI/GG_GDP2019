﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InControl;

public class PlayersSelectionManager : MonoBehaviour
{

    private PlayerSelection[] playersSelection;
    public PlayerSelection PrefabPanel;

    //Positionnement des panels
    public float SpaceBetweenTwoPanels = 250;
    public float posXInitial = 200;
    private float posYInitial = 200;

    //Gestion des joueurs prêts/connectés
    private bool[] PlayersReady;
    private bool[] PlayersHere;
    private int numberOfPlayersReady;
    private int numberOfPlayersConnected;

    //Pour savoir dans quelle scene on est
    private int SceneName;
    private const int START_SCENE = 0;
    private const int SELECT_SCENE = 1;
    private const int CREDITS_SCENE = 2;
    private const int INSTRUCTIONS_SCENE = 3;

    [SerializeField]
    public PlayerSelection[] playersSelec;

    public MenuManager menuManager;

    [SerializeField]
    private AudioClip broom_on;
    [SerializeField]
    private AudioClip vacuum_on;
    [SerializeField]
    private AudioClip ready;

    // Start is called before the first frame update
    void Start()
    {
        PlayersReady = new bool[4];
        PlayersHere = new bool[4];
        numberOfPlayersReady = 0;
        numberOfPlayersConnected = 0;

        SpaceBetweenTwoPanels = (Screen.width - posXInitial / 2) / 4;
        posXInitial = Screen.width / 8;
        posYInitial = Screen.height / 3;

        playersSelection = new PlayerSelection[4];

        playersSelection = playersSelec;
        for (int i = 0; i < 4; i++)
        {
            playersSelec[i].GetComponent<Image>().color = CommonProperties.Instance._colors[i];
        }
        PlayerSelection.tryLaunch += TestLaunchGame;
    }

    public void resetSelection()
    {
        numberOfPlayersReady = 0;
        numberOfPlayersConnected = 0;
        for (int i = 0; i < 4; i++)
        {
            PlayersHere[i] = false;
            PlayersReady[i] = false;
            playersSelection[i].pret = false;
            playersSelection[i].present = false;
            playersSelection[i].GetComponent<Animator>().SetBool("Ready", false);
            playersSelection[i].imgPret.color = Color.clear;
        }
    }

    void OnDisable()
    {
        PlayerSelection.tryLaunch -= TestLaunchGame;
    }

    public void setSceneName(int i)
    {
        SceneName = i;
    }

    // Update is called once per frame
    void Update()
    {
        numberOfPlayersReady = 0;
        numberOfPlayersConnected = Controls.Instance.GamePads.Count;

        if (SceneName == SELECT_SCENE)
        {
            for (int i = 0; i < PlayersReady.Length; i++)
            {
                if (!PlayersReady[i])
                {
                    if (i < numberOfPlayersConnected)
                    {
                        InputDevice inputDevice = Controls.Instance.GetPlayer(i);

                        AudioSource audioSource = playersSelection[i].GetComponent<AudioSource>();

                        if (inputDevice.Action1.WasPressed && !PlayersHere[i])
                        {
                            Debug.Log("Player Here !!");
                            playersSelection[i].present = true;
                            PlayersHere[i] = true;
                        }
                        else if (PlayersHere[i])
                        {
                            if (inputDevice.Action1.WasPressed)
                            {
                                Debug.Log("Player Ready !!");
                                PlayersReady[i] = true;
                                numberOfPlayersReady++;
                                playersSelection[i].pret = true;
                                playersSelection[i].GetComponent<Animator>().SetBool("Ready", true);
                                audioSource.clip = ready;
                                audioSource.Play();

                            }
                            else if (inputDevice.Direction.WasPressed && inputDevice.Direction.X > 0)
                            {
                                playersSelection[i].PersoSuivant();
                                if (playersSelection[i].WeaponDisplay.SelectedImage == 0)
                                {
                                    audioSource.clip = broom_on;
                                    
                                }
                                else
                                    audioSource.clip = vacuum_on;
                                audioSource.Play();
                            }
                            else if (inputDevice.Direction.WasPressed && inputDevice.Direction.X < 0)
                            {
                                playersSelection[i].PersoPrecedent();
                                if (playersSelection[i].WeaponDisplay.SelectedImage == 0)
                                {
                                    audioSource.clip = broom_on;

                                }
                                else
                                    audioSource.clip = vacuum_on;
                                audioSource.Play();
                            }
                        }
                    }
                }
                else
                    numberOfPlayersReady++;
            }
        }
    }
    public void TestLaunchGame()
    {
        if (numberOfPlayersConnected == numberOfPlayersReady && numberOfPlayersConnected != 0)
        {
            int playerCount = 0;

            for (int i = 0; i < playersSelection.Length; i++)
            {
                if (playersSelection[i].present)
                    playerCount++;
            }
            int[] playerSel = new int[playerCount];

            for (int i = 0; i < playersSelection.Length; i++)
            {
                if (playersSelection[i].present)
                    playerSel[playersSelection[i].Number] = playersSelection[i].WeaponDisplay.SelectedImage;
            }
            GameManager.Instance.playerSelection = playerSel;
            menuManager.launching();
        }
    }
}
