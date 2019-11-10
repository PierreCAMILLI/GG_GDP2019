using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class MenuManager : MonoBehaviour
{

    private bool[] PlayersReady;
    private int numberOfPlayersReady;
    private int numberOfPlayersConnected;

    void Start()
    {
        PlayersReady = new bool[4];
        numberOfPlayersReady = 0;
        numberOfPlayersConnected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            //GameManager.Instance.NewGame();
        }

        numberOfPlayersReady = 0;

        for (int i = 0; i < PlayersReady.Length; i++)
        {
            if (!PlayersReady[i])
            {
                InputDevice inputDevice = Controls.Instance.GetPlayer(i);
                if (inputDevice.Action1.IsPressed || inputDevice.Action2.IsPressed || inputDevice.Action3.IsPressed || inputDevice.Action4.IsPressed)
                {
                    PlayersReady[i] = true;
                    numberOfPlayersReady++;
                }
            }
            else
                numberOfPlayersReady++;
        }

    }
}
