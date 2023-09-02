public class GuardIdleState : GuardState
{
    public override void OnEnter()
    {
        Controller.TransitionToPatrol(); // For now go straight to patrol.
    }
}
