using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float _speed;

    Vector3 _target;

    public event Action OnTargetReached;

    public void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

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
