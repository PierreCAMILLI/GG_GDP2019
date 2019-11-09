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
        playersSelection = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            PlayerSelection playerSelec = Instantiate(PrefabPanel, GetComponent<Canvas>().transform);

            playerSelec.Number = i;
            playersSelection[i] = playerSelec.gameObject;

            playerSelec.transform.SetPositionAndRotation(new Vector3(posXInitial + i * SpaceBetweenTwoPanels, posYInitial, 0), Quaternion.identity);
            playerSelec.GetComponent<Image>().color = CommonProperties.Instance._colors[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
