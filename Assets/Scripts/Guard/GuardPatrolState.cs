using UnityEngine;

public class GuardPatrolState : GuardState
{
    public override void OnEnter()
    {
        var point = Controller.WaypointCollection.Points[Random.Range(0, Controller.WaypointCollection.Points.Length-1)];
        Controller.Movement.SetTarget(point);
    }

    public override void OnUpdate()
    {
        Controller.Movement.MoveTowardsTarget();
        if (Controller.Movement.IsAtTarget())
        {
            Controller.TransitionToIdle();
        }
    }
}
