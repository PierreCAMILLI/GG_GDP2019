﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeapon : ScriptableObject
{
    public enum UseState
    {
        Down,
        Pressed,
        Up
    }

    public enum TypeEnum
    {
        Broom,
        Vacuum,
        Blower
    }

    #region Serialize Field
    [SerializeField]
    private TypeEnum _type;
    public TypeEnum Type
    {
        get { return _type; }
    }
    #endregion

    #region Variables
    private Hero _hero;
    public Hero Hero
    {
        get { return _hero; }
    }
    #endregion

    public void Init(Hero hero)
    {
        _hero = hero;
        OnAwake(hero);
    }

    // Called once when the game starts
    public virtual void OnAwake(Hero hero) { }

    // Called when the button is pressed
    public virtual void OnUseDown(Hero hero) { }

    // Called each frame when the button is pressed
    public virtual void OnUse(Hero hero) { }
    
    // Called when the button is released
    public virtual void OnUseUp(Hero hero) { }
}
