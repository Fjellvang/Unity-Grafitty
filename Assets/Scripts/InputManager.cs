using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlayerInput _playerInput;
    bool _isPressing = false;
    Vector2 _startPosition;
    [SerializeField, Range(1f, 300f)]
    float _maxJoystickLength; // TODO: find a better name for this, its how far the finger should slide

    [SerializeField]
    PlayerInputData _playerInputData;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void Start()
    {
        _playerInput.Player.Move.started += Move_started;
        _playerInput.Player.Move.canceled += Move_canceled;
        _playerInput.Player.JumpInteract.started += JumpInteract_started;
    }

    private void JumpInteract_started(InputAction.CallbackContext context)
    {
        _playerInputData.OnInteract();
    }

    private void Update()
    {
        _playerInputData.Move = Vector2.zero;
        if (_isPressing)
        {
            var value = _playerInput.Player.Move.ReadValue<Vector2>();
            var delta = value - _startPosition;

            var maxLengthSquared = _maxJoystickLength * _maxJoystickLength;

            if (delta.sqrMagnitude > maxLengthSquared)
            {
                delta = delta.normalized * _maxJoystickLength;
            }

            delta /= _maxJoystickLength;

            _playerInputData.Move = delta;
        }
    }

    private void Move_canceled(InputAction.CallbackContext obj)
    {
        _isPressing = false;
    }

    private void Move_started(InputAction.CallbackContext obj)
    {
        _isPressing = true;
        var value = obj.ReadValue<Vector2>();
        _startPosition = value;
    }
}
