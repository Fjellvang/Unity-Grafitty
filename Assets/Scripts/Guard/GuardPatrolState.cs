using UnityEngine;
using UnityEngine.AI;

public class GuardPatrolState : GuardState
{
    public override void OnEnter()
    {
        var point = Controller.WaypointCollection.Points[Random.Range(0, Controller.WaypointCollection.Points.Length-1)];
        Controller.NavMeshAgent.SetDestination(point);
    }

    public override void OnUpdate()
    {
        if (Controller.Vision.PlayerVisible)
        {
            Controller.TransitionToChase();
        }

        if (Controller.NavMeshAgent.remainingDistance <= Controller.NavMeshAgent.stoppingDistance)
        {
            Controller.TransitionToIdle();
        }
    }
}
