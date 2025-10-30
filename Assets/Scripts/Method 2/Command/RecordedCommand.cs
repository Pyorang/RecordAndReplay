using UnityEngine;

public class RecordedCommand : ICommand, IReturnTime
{
    protected float _time;
    protected GameObject _gameObject;

    public virtual void Execute() { }

    public float ReturnTime()
    {
        return _time;
    }
}
