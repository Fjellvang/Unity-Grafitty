using UnityEngine;

public class GuardVision : MonoBehaviour
{
    [SerializeField]
    GuardController _controller;

    bool _playerVisible;
    public bool PlayerVisible => _playerVisible;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return; 
        }

        var guardDirection = _controller.Movement.Direction;
        var playerDirection = other.transform.position - transform.position;

        var angle = Vector3.Angle(guardDirection, playerDirection);
        Debug.Log($"ANGLE: {angle}");

        _playerVisible = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        _playerVisible = false;
    }
}