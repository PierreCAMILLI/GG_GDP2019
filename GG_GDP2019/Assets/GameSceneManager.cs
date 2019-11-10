﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField]
    private Transform heroes;

    [SerializeField]
    private GameObject[] heroModels;

    [SerializeField]
    private Transform[] baseHeroesPositions;
    // Start is called before the first frame update
    void Start()
    {
        int[] playSels = GameManager.Instance.playerSelection;
        for (int i = 0; i < playSels.Length; i++)
        {
            int playSel = playSels[i];
            CreateHero(playSel, i);
        }
    }

    private void CreateHero(int playSel, int playNum)
    {
        GameObject hero = Instantiate(heroModels[playSel]);
        hero.transform.parent = heroes;
        hero.transform.position = baseHeroesPositions[playNum].position;
        hero.transform.rotation = baseHeroesPositions[playNum].rotation;
        HeroController heroController = hero.GetComponent<HeroController>();
        heroController.playerNumber = playNum;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}