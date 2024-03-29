﻿using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonScriptable<T> : ScriptableObject where T : ScriptableObject
{
    static T _instance = null;
    public static T Instance
    {
        get
        {
            if (!_instance)
                _instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
            return _instance;
        }
    }
}
