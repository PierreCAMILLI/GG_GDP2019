using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersSelectionManager : MonoBehaviour
{

    private GameObject[] playersSelection;
    public PlayerSelection PrefabPanel;
    public float SpaceBetweenTwoPanels = 250;
    public float posXInitial = 200;
    public float posYInitial = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpaceBetweenTwoPanels = (Screen.width - posXInitial/2) / 4;
        posXInitial = Screen.width / 8;
        posYInitial = Screen.height / 2;

        playersSelection = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            PlayerSelection playerSelec = Instantiate(PrefabPanel, GetComponent<Canvas>().transform);

            playerSelec.Number = i;
            playersSelection[i] = playerSelec.gameObject;

            playerSelec.transform.SetPositionAndRotation(new Vector3(posXInitial + i * SpaceBetweenTwoPanels, posYInitial, 0), Quaternion.identity);
            playerSelec.GetComponent<Image>().color = CommonProperties.Instance._colors[i];

            //playerSelec.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
