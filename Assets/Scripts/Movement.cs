using System;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float _speed;
    [SerializeField]
    float _targetArriveDisance = 0.1f;

    Vector3 _target;
    Vector3 _direction;
    public Vector3 Direction => _direction;

    public bool IsAtTarget() => Vector3.Distance(transform.position, _target) < _targetArriveDisance;

    public void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        var dir = _target - transform.position;
        _direction = new Vector3(dir.x, 0, dir.z).normalized;

        var look = Quaternion.LookRotation(_direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, look, 0.15f);
    }

    public void SetTarget(Vector3 target)
    {
        _target = target;
    }
}
