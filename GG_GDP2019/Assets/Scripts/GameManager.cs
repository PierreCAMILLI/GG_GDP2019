﻿using InControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    private Animator animator;

    [Header("Timer")]
    [HideInInspector]
    public float timer;
    [SerializeField]
    private float baseTimer;
    public float BaseTimer
    {
        get => baseTimer;
    }

    override protected void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();

    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver() {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Game"))
            animator.SetTrigger("gameOver");
    }

    public void Quit() {
        animator.SetTrigger("quit"); 
    }
    public void NewGame() {
        animator.ResetTrigger("gameOver");
        animator.SetTrigger("newGame"); 
    }
    public void Pause() {
        animator.SetTrigger("pause"); 
    }
    public void Resume() {
        animator.SetTrigger("resume"); 
    }

    public void StartGame()
    {
        animator.SetTrigger("StartGame");
    }

}
