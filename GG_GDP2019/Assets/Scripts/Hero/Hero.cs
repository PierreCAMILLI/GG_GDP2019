using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Hero : MonoBehaviour
{
    #region Components
    private CharacterController _characterController;
    #endregion

    #region Serializable Fields
    [SerializeField]
    private float _speed;
    public float Speed
    {
        get { return _speed; }
    }

    [Header("Rotation")]
    [SerializeField]
    private float _rotationSpeed;

    [SerializeField]
    private float _magnitudeSpeed;

    [Space]
    [Header("Weapons")]
    [SerializeField]
    private AbstractWeapon.TypeEnum _usedWeapon;
    public AbstractWeapon.TypeEnum UsedWeapon
    {
        get { return _usedWeapon; }
        set { _usedWeapon = value; }
    }
    [SerializeField]
    private AbstractWeapon[] _weapons;
    #endregion

    #region Private Variables
    private Vector2 _direction;

    private Dictionary<AbstractWeapon.TypeEnum, AbstractWeapon> _weaponsDict;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        
        _weaponsDict = _weapons.ToDictionary(w => w.Type);
    }

    void FixedUpdate()
    {
        Vector3 direction = _direction.XZ() * _speed;
        _characterController.SimpleMove(direction);
        if (direction.sqrMagnitude > Mathf.Epsilon)
        {
            Vector3 forwardTarget = Vector3.RotateTowards(transform.forward, direction, _rotationSpeed * Time.fixedDeltaTime, _magnitudeSpeed * Time.fixedDeltaTime);
            transform.forward = forwardTarget;
        }
        _direction = Vector2.zero;
    }
    #endregion

    #region Public Methods
    public void Move(Vector2 direction)
    {
        _direction = direction;
    }

    public void UseWeapon(AbstractWeapon.TypeEnum type, AbstractWeapon.UseState state)
    {
        switch (state)
        {
            case AbstractWeapon.UseState.Down:
                _weaponsDict[type].OnUseDown();
                break;
            case AbstractWeapon.UseState.Pressed:
                _weaponsDict[type].OnUse();
                break;
            case AbstractWeapon.UseState.Up:
                _weaponsDict[type].OnUseUp();
                break;
        }
    }

    public void UseWeapon(AbstractWeapon.UseState state)
    {
        UseWeapon(_usedWeapon, state);
    }
    #endregion

    #region Private Methods
    #endregion
}
