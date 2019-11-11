using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUIScript : MonoBehaviour
{
    [SerializeField]
    private GameObject scoreText;
    [SerializeField]
    private GameObject gameOverText;

    private bool hasOver;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.SetActive(false); 
        gameOverText.SetActive(false);
        hasOver = false;
    }
    public void GameOver()
    {

        scoreText.GetComponent<Text>().text = "Vous avez atteint le level " + GameManager.Instance.level;
        scoreText.SetActive(true);
        gameOverText.SetActive(true);
        GameManager.Instance.level = 0;
        GameManager.Instance.difficulty = 0;

    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsState("GameOver") && !hasOver)
        {
            hasOver = true;
            GameOver();
            
        }
    }
}
