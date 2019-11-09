using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Controls", menuName = "Controls/Controls (Singleton)", order = 1)]
public class Controls : SingletonScriptable<Controls>
{
    [SerializeField]
    private PlayerInputs[] _playerInputs;

    public PlayerInputs GetPlayer(int i)
    {
        return _playerInputs[i];
    }
}
