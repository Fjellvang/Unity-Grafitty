using UnityAtoms.BaseAtoms;
using UnityEngine;

public class GuardChaseState : GuardState
{
    [SerializeField]
    Vector3Variable _playerPosition;

    public override void OnUpdate()
    {
        if (!Controller.Vision.PlayerVisible)
        {
            //TODO: Introduce cooldown state. Maybe a search state ???
            Controller.TransitionToPatrol();
        }

        Controller.NavMeshAgent.SetDestination(_playerPosition.Value);
    }
}
