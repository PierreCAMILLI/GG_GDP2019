using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CommonProperties", menuName = "CommonProperties", order = 1)]
public class CommonProperties : SingletonScriptable<CommonProperties>
{
    [SerializeField]
    public Color[] _colors;
}
