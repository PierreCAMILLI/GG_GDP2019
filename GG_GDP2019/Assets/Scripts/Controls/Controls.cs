﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using InControl;

[CreateAssetMenu(fileName = "Controls", menuName = "Controls/Controls (Singleton)", order = 1)]
public class Controls : SingletonBehaviour<Controls>
{
    public List<InputDevice> GamePads;
    public int PlayerCount
    {
        get { return GamePads.Count; }
    }

    void Start()
    {
        GamePads = new List<InputDevice>();
    }

    void Update()
    {
        //if (GamePads.Count < 4 && GameManager.Instance.State == "MenuSelection")
        if (GamePads.Count < 4)
        {
            UpdatePlayerNumber();
        }
    }

    private void UpdatePlayerNumber()
    {
        for (int i = 0; i < InputManager.ActiveDevices.Count; i++)
        {
            InputDevice device = InputManager.ActiveDevices[i];
            if (device.IsAttached && !(GamePads.Contains(device)))
            {
                GamePads.Add(device);
            }
        }
    }

    public void ClearPlayers()
    {
        GamePads.Clear();
    }

    public InputDevice GetPlayer(int i)
    {
        return GamePads[i];
    }
}
