using System.Collections;
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

    [SerializeField]
    private float[] tints;
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
        GameObject hero = Instantiate(heroModels[playSel], baseHeroesPositions[playNum].position, baseHeroesPositions[playNum].rotation, heroes);
        HeroController heroController = hero.GetComponent<HeroController>();
        heroController.playerNumber = playNum;
        hero.transform.Find("Circle").GetComponent<Circle_chara>().color = CommonProperties.Instance._colors[playNum];

        foreach (Renderer r in hero.transform.Find("perso").GetComponentsInChildren<Renderer>())
            r.material.mainTextureScale = new Vector2(tints[playSel * 4 + playNum], tints[playSel * 4 + playNum]);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
