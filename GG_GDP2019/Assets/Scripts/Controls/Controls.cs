using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using InControl;

[CreateAssetMenu(fileName = "Controls", menuName = "Controls/Controls (Singleton)", order = 1)]
public class Controls : SingletonBehaviour<Controls>
{
    public List<InputDevice> GamePads;

    [SerializeField]
    private PlayerInputs[] _playerInputs;

    void Start()
    {
        GamePads = new List<InputDevice>();
    }

    void Update()
    {
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
        Debug.Log(i);
        return GamePads[i];
    }
}
