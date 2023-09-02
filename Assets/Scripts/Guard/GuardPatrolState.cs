using UnityEngine;

public class GuardPatrolState : GuardState
{
    public override void OnEnter()
    {
        var point = Controller.WaypointCollection.Points[Random.Range(0, Controller.WaypointCollection.Points.Length-1)];
        Controller.Movement.SetTarget(point);

        Controller.Movement.OnTargetReached += Movement_OnTargetReached;
    }

    private void Movement_OnTargetReached()
    {
        Controller.TransitionToIdle();
    }

    public override void OnUpdate()
    {
        Controller.Movement.MoveTowardsTarget();
    }
}
