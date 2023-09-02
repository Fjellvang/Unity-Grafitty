using UnityEngine;

public class GuardController : MonoBehaviour
{
    StateMachine<GuardState> _stateMachine = new();
    [SerializeField]
    GuardPatrolState _patrolState;
    [SerializeField]
    GuardIdleState _idleState;

    public Movement Movement;
    public WaypointCollection WaypointCollection;

    void Start()
    {
        _stateMachine.Initialize(_idleState);
    }

    public void Update()
    {
        _stateMachine.Update();
    }

    [ContextMenu("Idle")]
    public void TransitionToIdle()
    {
        _stateMachine.TransitionTo(_idleState);
    }

    [ContextMenu("Patrol")]
    public void TransitionToPatrol()
    {
        _stateMachine.TransitionTo(_patrolState);
    }
}
