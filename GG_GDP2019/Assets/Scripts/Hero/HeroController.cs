using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Hero))]
public class HeroController : MonoBehaviour
{
    private Hero _hero;

    private PlayerInputs _inputs;

    [SerializeField]
    private int _playerNumber;

    void Awake()
    {
        _hero = GetComponent<Hero>();
        _inputs = Controls.Instance.GetPlayer(_playerNumber);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_inputs.Weapon))
        {
            _hero.UseWeapon(AbstractWeapon.UseState.Down);
        }
        if (Input.GetKey(_inputs.Weapon))
        {
            _hero.UseWeapon(AbstractWeapon.UseState.Pressed);
        }
        if (Input.GetKeyUp(_inputs.Weapon))
        {
            _hero.UseWeapon(AbstractWeapon.UseState.Up);
        }

    }

    private void FixedUpdate()
    {
        _hero.Move(InputToHeroDirection(_inputs.Direction));
    }

    private Vector2 InputToHeroDirection(Vector2 direction)
    {
        Transform _directionTransform = Camera.main.transform;
        Vector2 forward = _directionTransform.forward.XZ().normalized;
        Vector2 right = _directionTransform.right.XZ().normalized;
        return direction.x * right + direction.y * forward;
    }
}
