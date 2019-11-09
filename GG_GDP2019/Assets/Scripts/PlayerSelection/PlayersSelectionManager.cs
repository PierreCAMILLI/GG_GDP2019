using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersSelectionManager : MonoBehaviour
{

    private GameObject[] playersSelection;
    public RectTransform FirstPanel;
    public PlayerSelection PrefabPanel;
    private float SpaceBetweenTwoPanels;
    private float posXInitial, posYInitial;

    // Start is called before the first frame update
    void Start()
    {
        posXInitial = FirstPanel.transform.position.x;
        posYInitial = FirstPanel.transform.position.y;

        SpaceBetweenTwoPanels = ((1920 - 2*posXInitial)-4*(FirstPanel.rect.width * FirstPanel.localScale.x))/4;
        playersSelection = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            PlayerSelection playerSelec = FirstPanel.GetComponent<PlayerSelection>();
            if (i != 0)
                playerSelec = Instantiate(PrefabPanel, FirstPanel.parent.transform);

            playerSelec.Number = i;
            playersSelection[i] = playerSelec.gameObject;

            playerSelec.transform.SetPositionAndRotation(new Vector3(posXInitial + i * ((FirstPanel.rect.width*FirstPanel.localScale.x)+ SpaceBetweenTwoPanels), posYInitial, 0), Quaternion.identity);
            playerSelec.GetComponent<Image>().color = CommonProperties.Instance._colors[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
