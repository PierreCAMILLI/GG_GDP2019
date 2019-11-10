using InControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IconAboveHeadUI))]
public class IconAboveHeroUI : MonoBehaviour
{
    [SerializeField]
    private int _playerNumber;

    private IconAboveHeadUI _icon;

    // Start is called before the first frame update
    void Awake()
    {
        _icon = GetComponent<IconAboveHeadUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _icon.Transform = (Hero.Heroes != null && Hero.Heroes.Count > _playerNumber ?
                                Hero.Heroes[_playerNumber].transform :
                                null);
        if (Controls.Instance.PlayerCount > _playerNumber && Controls.Instance.GetPlayer(_playerNumber).Action1.WasPressed)
        {
            _icon.gameObject.SetActive(false);
        }
    }
}
