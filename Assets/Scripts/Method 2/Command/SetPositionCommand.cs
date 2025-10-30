using Unity.VisualScripting;
using UnityEngine;

public class SetPositionCommand : RecordedCommand
{
    private Vector3 _position;

    public SetPositionCommand(GameObject gameObject, float time)
    {
        this._gameObject = gameObject;
        this._position = gameObject.transform.position;
        this._time = time;
    }

    public override void Execute()
    {
        _gameObject.transform.position = _position;
    }
}
