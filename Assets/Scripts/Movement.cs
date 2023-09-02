using System;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float _speed;

    Vector3 _target;
    Vector3 _direction;
    public Vector3 Direction => _direction;

    public event Action OnTargetReached;

    public void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        var dir = _target - transform.position;
        _direction = new Vector3(dir.x, 0, dir.z).normalized;

        transform.rotation = Quaternion.LookRotation(_direction);

        if (transform.position == _target)
        {
            OnTargetReached?.Invoke();
        }
    }

    public void SetTarget(Vector3 target)
    {
        _target = target;
    }
}
public interface IState
{
    /// <summary>
    /// Code that runs when we enter the state.
    /// </summary>
    void OnEnter();

    /// <summary>
    /// Code that runs every frame while we are in the state. Should include a condition to transition to a new state.
    /// </summary>
    void OnUpdate();

    /// <summary>
    /// Code that runs when we exit the state.
    /// </summary>
    void OnExit();
}
