using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

[RequireComponent(typeof(Hero))]
public class HeroController : MonoBehaviour
{
    private Hero _hero;

    private InputDevice _inputs;

    [SerializeField]
    private int _playerNumber;

    void OnEnable()
    {
        _hero = GetComponent<Hero>();
    }

    // Update is called once per frame
    void Update()
    {
        _inputs = Controls.Instance.GetPlayer(_playerNumber);
        if (_inputs.Action1.WasPressed)
        {
            _hero.UseWeapon(AbstractWeapon.UseState.Down);
        }
        if (_inputs.Action1.WasReleased)
        {
            _hero.UseWeapon(AbstractWeapon.UseState.Up);
        }
    }

    private void FixedUpdate()
    {
        _inputs = Controls.Instance.GetPlayer(_playerNumber);
        _hero.Move(InputToHeroDirection(_inputs.Direction.Vector));
    }

    private Vector2 InputToHeroDirection(Vector2 direction)
    {
        Transform _directionTransform = Camera.main.transform;
        Vector2 forward = _directionTransform.forward.XZ().normalized;
        Vector2 right = _directionTransform.right.XZ().normalized;
        return direction.x * right + direction.y * forward;
    }
}
