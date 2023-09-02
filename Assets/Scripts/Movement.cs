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
