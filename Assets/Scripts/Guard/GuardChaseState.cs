public class GuardChaseState : GuardState
{
    public override void OnUpdate()
    {
        if (!Controller.Vision.PlayerVisible)
        {
            //TODO: Introduce cooldown state. Maybe a search state ???
            Controller.TransitionToPatrol();
        }
    }
}
