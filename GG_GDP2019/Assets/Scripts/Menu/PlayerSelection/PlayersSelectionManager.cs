using System.Collections;
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
    public GameObject CanvasRef;

    // Start is called before the first frame update
    void Start()
    {
        PlayersReady = new bool[4];
        PlayersHere = new bool[4];
        numberOfPlayersReady = 0;
        numberOfPlayersConnected = 0;

        SpaceBetweenTwoPanels = (Screen.width - posXInitial/2) / 4;
        posXInitial = Screen.width / 8;
        posYInitial = Screen.height / 3;

        playersSelection = new PlayerSelection[4];
        for (int i = 0; i < 4; i++)
        {
            PlayerSelection playerSelec = Instantiate(PrefabPanel, CanvasRef.transform);

            playerSelec.Number = i;
            playersSelection[i] = playerSelec;

            playerSelec.transform.SetPositionAndRotation(new Vector3(posXInitial + i * SpaceBetweenTwoPanels, posYInitial, 0), Quaternion.identity);
            playerSelec.GetComponent<Image>().color = CommonProperties.Instance._colors[i];

            //playerSelec.gameObject.SetActive(false);
        }

        PlayerSelection.tryLaunch += TestLaunchGame;
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

                            }
                            else if (inputDevice.Direction.WasPressed && inputDevice.Direction.X > 0)
                            {
                                playersSelection[i].PersoSuivant();
                            }
                            else if (inputDevice.Direction.WasPressed && inputDevice.Direction.X < 0)
                            {
                                playersSelection[i].PersoPrecedent();
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
                if(playersSelection[i].present)
                    playerSel[playersSelection[i].Number] = playersSelection[i].WeaponDisplay.SelectedImage;
            }
            GameManager.Instance.playerSelection = playerSel;
            GameManager.Instance.NewGame();
        }
    }
}
