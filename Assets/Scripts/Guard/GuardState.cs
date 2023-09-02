using Dwarf.DesignPatterns.State;
using UnityEngine;

public class GuardState : MonoBehaviour, IState
{
    public GuardController Controller;
    public virtual void OnEnter()
    {
    }

    public virtual void OnExit()
    {
    }

    public virtual void OnUpdate()
    {
    }
}
