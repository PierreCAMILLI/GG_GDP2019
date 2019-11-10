using InControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    private Animator animator;
    public InputDevice[] GamePads;
    private int j = 0;

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
        GamePads = new InputDevice[4];

        for (int i = 0; i < InputManager.ActiveDevices.Count; i++)
        {
            if (InputManager.ActiveDevices[i].IsAttached)
            {
                GamePads[j] = InputManager.ActiveDevices[i];
                Debug.Log(GamePads[j].GUID);
                j++;
                if (j >= 4)
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Input update
        

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
    
}
