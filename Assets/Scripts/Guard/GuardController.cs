using UnityEngine;
using UnityEngine.AI;

[SelectionBase]
public class GuardController : MonoBehaviour
{
    StateMachine<GuardState> _stateMachine = new();
    [SerializeField]
    GuardPatrolState _patrolState;
    [SerializeField]
    GuardIdleState _idleState;
    [SerializeField]
    GuardChaseState _chaseState;

    public GuardVision Vision;
    public NavMeshAgent NavMeshAgent;
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

    public void TransitionToChase()
    {
        _stateMachine.TransitionTo(_chaseState);
    }
}
