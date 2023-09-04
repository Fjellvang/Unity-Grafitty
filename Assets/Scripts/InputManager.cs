using UnityAtoms.BaseAtoms;
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
    Vector2Variable _playerMoveInput;

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
    }
    private void Update()
    {
        _playerMoveInput.Value = Vector2.zero;
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

            Debug.Log(delta.magnitude);
            _playerMoveInput.Value = delta; 
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
