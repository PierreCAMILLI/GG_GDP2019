using System.Collections;
using System.Collections.Generic;
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

    [SerializeField]
    private float _rotationSpeed;

    [SerializeField]
    private float _magnitudeSpeed;
    #endregion

    #region
    private Vector2 _direction;
    private Vector3 _forwardTarget;
    #endregion

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        Vector3 direction = _direction.XZ() * _speed;
        _characterController.SimpleMove(direction);
        if (direction.sqrMagnitude > Mathf.Epsilon)
        {
            _forwardTarget = Vector3.RotateTowards(transform.forward, direction, _rotationSpeed * Time.fixedDeltaTime, _magnitudeSpeed * Time.fixedDeltaTime);
            transform.forward = _forwardTarget;
        }
        _direction = Vector2.zero;
    }

    public void Move(Vector2 direction)
    {
        _direction = direction;
    }
}
