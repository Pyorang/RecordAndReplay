using UnityEngine;

public class ReplayCommand : ICommand, IReturnTime
{
    protected float time;
    protected PlayerController playerController;

    public virtual void Execute() { }

    public float ReturnTime()
    {
        return time;
    }
}
