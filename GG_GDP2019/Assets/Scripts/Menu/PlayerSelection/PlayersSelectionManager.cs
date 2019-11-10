using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InControl;

public class PlayersSelectionManager : MonoBehaviour
{

    private GameObject[] playersSelection;
    public PlayerSelection PrefabPanel;

    //Positionnement des panels
    public float SpaceBetweenTwoPanels = 250;
    public float posXInitial = 200;
    public float posYInitial = 0;

    //Gestion des joueurs prêts/connectés
    private bool[] PlayersReady;
    private bool[] PlayersHere;
    private int numberOfPlayersReady;
    private int numberOfPlayersConnected;

    // Start is called before the first frame update
    void Start()
    {
        PlayersReady = new bool[4];
        PlayersHere = new bool[4];
        numberOfPlayersReady = 0;
        numberOfPlayersConnected = 0;

        SpaceBetweenTwoPanels = (Screen.width - posXInitial/2) / 4;
        posXInitial = Screen.width / 8;
        posYInitial = Screen.height / 2;

        playersSelection = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            PlayerSelection playerSelec = Instantiate(PrefabPanel, GetComponent<Canvas>().transform);

            playerSelec.Number = i;
            playersSelection[i] = playerSelec.gameObject;

            playerSelec.transform.SetPositionAndRotation(new Vector3(posXInitial + i * SpaceBetweenTwoPanels, posYInitial, 0), Quaternion.identity);
            playerSelec.GetComponent<Image>().color = CommonProperties.Instance._colors[i];

            //playerSelec.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        numberOfPlayersReady = 0;
        numberOfPlayersConnected = Controls.Instance.GamePads.Count;

        for (int i = 0; i < PlayersReady.Length; i++)
        {
            if (!PlayersReady[i])
            {
                if (i < numberOfPlayersConnected)
                {
                    InputDevice inputDevice = Controls.Instance.GetPlayer(i);
                    if (inputDevice.Action1 && !PlayersHere[i])
                    {
                        Debug.Log("Player Here !!");
                        PlayersHere[i] = true;
                    }
                    else if (inputDevice.Action1 && PlayersHere[i])
                    {
                        Debug.Log("Player Ready !!");
                        PlayersReady[i] = true;
                        numberOfPlayersReady++;
                    }
                }
            }
            else
                numberOfPlayersReady++;
        }
        if(numberOfPlayersConnected == numberOfPlayersReady && numberOfPlayersConnected != 0)
        {
            GameManager.Instance.NewGame();
        }
    }
}
