using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Hero : MonoBehaviour
{
    #region Components
    private CharacterController _characterController;
    private Rigidbody _rigidbody;
    [SerializeField]
    Animator m_Animator;

    public bool lockDirection;

    public Animator Animator
    {
        get { return m_Animator; }
    }
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

    [SerializeField]
    private AbstractWeapon[] _weaponsInstance;
    #endregion

    #region Private Variables
    private static List<Hero> _heroes;
    public static IList<Hero> Heroes
    {
        get { return _heroes; }
    }

    private Vector2 _direction;

    private Dictionary<AbstractWeapon.TypeEnum, AbstractWeapon> _weaponsDict;
    #endregion

    #region Unity Methods

    private void Awake()
    {
        if (_heroes == null)
        {
            _heroes = new List<Hero>();
        }
        _heroes.Add(this);
        _characterController = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody>();

        _weaponsDict = _weapons.ToDictionary(w => w.Type);

        foreach (AbstractWeapon weapon in _weapons) {
            weapon.OnAwake(this);
        }
    }

    void OnDestroy()
    {
        _heroes.Remove(this);
    }

    void FixedUpdate()
    {
        Vector3 direction = _direction.XZ() * _speed;
        if (_characterController != null && _characterController.enabled)
        {
            _characterController.SimpleMove(direction);
        } else if (_rigidbody)
        {
            // _rigidbody.MovePosition(transform.position + direction * Time.fixedDeltaTime);
            _rigidbody.AddForce(direction, ForceMode.VelocityChange);
        }
        if (direction.sqrMagnitude > 0.1f && !lockDirection)
        {
            Vector3 forwardTarget = Vector3.RotateTowards(transform.forward, direction, _rotationSpeed * Time.fixedDeltaTime, _magnitudeSpeed * Time.fixedDeltaTime);
            transform.forward = forwardTarget;
        }
        _direction = Vector2.zero;
        
        m_Animator.SetFloat("Speed", direction.magnitude);
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
                _weaponsDict[type].OnUseDown(this);
                break;
            case AbstractWeapon.UseState.Pressed:
                _weaponsDict[type].OnUse(this);
                break;
            case AbstractWeapon.UseState.Up:
                _weaponsDict[type].OnUseUp(this);
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
