using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    #region Variables: Movement

    private CharacterController _characterController;
    private Vector3 _direction;
    [SerializeField]
    Vector3Variable _position;
    [SerializeField]
    Vector2Variable _moveInput;
    [SerializeField]
    FloatVariable _cameraAngle;

    [SerializeField] private float speed;

    #endregion
    #region Variables: Rotation

    [SerializeField] private float smoothTime = 0.05f;
    private float _currentVelocity;

    #endregion
    #region Variables: Gravity

    private float _gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3.0f;
    private float _velocity;

    #endregion
    #region Variables: Jumping

    [SerializeField] private float jumpPower;

    #endregion
    
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }


    private void Update()
    {
        var rotation = Quaternion.AngleAxis(-_cameraAngle.Value, Vector3.forward);
        var rotattedInput = rotation * _moveInput.Value;

        _direction = new Vector3(rotattedInput.x, 0, rotattedInput.y);
        ApplyGravity();
        ApplyRotation();
        ApplyMovement();
        _position.Value = transform.position;
    }

    private void ApplyGravity()
    {
        if (IsGrounded() && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }
        else
        {
            _velocity += _gravity * gravityMultiplier * Time.deltaTime;
        }
        
        _direction.y = _velocity;
    }
    
    private void ApplyRotation()
    {
        if (_moveInput.Value.sqrMagnitude == 0) return;
        
        var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
    }

    private void ApplyMovement()
    {
        _characterController.Move(speed * Time.deltaTime * _direction);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (!IsGrounded()) return;

        _velocity += jumpPower;
    }

    private bool IsGrounded() => _characterController.isGrounded;
}