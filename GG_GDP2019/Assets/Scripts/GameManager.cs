using InControl;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    [SerializeField]
    public int[] playerSelection;

    public float BaseTimer
    {
        get => baseTimer;
    }

    private float _greaterDetectionRate;
    public float GreaterDetectionRate
    {
        get { return _greaterDetectionRate; }
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
        UpdateGreaterDetectionRate();
    }

    void UpdateGreaterDetectionRate()
    {
        if (Spotlight.Spotlights != null && Spotlight.Spotlights.Count > 0)
        {
            _greaterDetectionRate = Spotlight.Spotlights.Where(s => s.isActiveAndEnabled).Max(s => s.DetectionRate);
        }
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
        Time.timeScale = 0f;
    }
    public void Resume() {
        animator.SetTrigger("resume");
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        animator.SetTrigger("StartGame");
    }

    public bool IsState(string name)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(name);
    }

}
