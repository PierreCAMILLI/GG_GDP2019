using InControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInputs", menuName = "Controls/Player Inputs", order = 2)]
public class PlayerInputs : ScriptableObject
{
    [SerializeField]
    private string _horizontalAxis;
    public float Horizontal
    {
        get {
            //InputDevice inputDevice;
            //return inputDevice.Direction.Value.x;
            return Input.GetAxis(_horizontalAxis); }
    }

    [SerializeField]
    private string _verticalAxis;
    public float Vertical
    {
        get { return Input.GetAxis(_verticalAxis); }
    }

    public Vector2 Direction
    {
        get {
            Vector2 dir = new Vector2(Horizontal, Vertical);
            if (dir.sqrMagnitude > 1f)
            {
                return dir.normalized;
            }
            return dir;
        }
    }

    [SerializeField]
    private KeyCode _weapon;
    public KeyCode Weapon
    {
        get { return _weapon; }
    }

}
