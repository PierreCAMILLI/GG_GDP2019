using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightGenerator : Generator
{
    [SerializeField]
    private Transform spotlights;

    [SerializeField]
    private Transform[] spotlightPositions;
    [SerializeField]
    public GameObject[] spotlightPrefabs;

    [SerializeField]
    private float minSpotDifficulty;

    [SerializeField]
    private float difficultyToSpeed;

    [SerializeField]
    private float speedDiffThreshold;

    [SerializeField]
    private float meanDifficultyToSpot;

    public override float Generate(float difficulty)
    {
        int spotNumber = (int) (Mathf.Log(difficulty / 100f, 2.6f));
        spotNumber += 1;

        float realDifficulty = minSpotDifficulty * (spotNumber);
        float diffPerSpot = (difficulty - realDifficulty) / spotNumber;
        for (int i = 0; i < spotNumber; i++)
        {

            
            GameObject spotlight = Instantiate(spotlightPrefabs[0]);
            SpotlightPositionController spc = spotlight.AddComponent<SpotlightPositionController>();
            spc.positions = spotlightPositions;
            spotlight.transform.parent = spotlights;
            spotlight.transform.position = spotlightPositions[Random.Range(0, spotlightPositions.Length)].position;
            spc.spotlight = spotlight.GetComponent<Spotlight>();
            spc.NewPosition();
            float speedAdd = diffPerSpot * difficultyToSpeed;
            spc.speed = 1f + speedAdd;
            spc.beginTime = 4f;
            realDifficulty += speedAdd;
        }
        return realDifficulty;
    }
}
