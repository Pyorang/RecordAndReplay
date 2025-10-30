using UnityEngine;

public class PlayerMoveCommand : RecordedCommand
{
    private PlayerController _playerController;
    private float _input;
    
    public  PlayerMoveCommand(PlayerController playerController, float time)
    {
        this._playerController = playerController;
        this._input = playerController.GetInput();
        this._time = time;
    }

    public override void Execute()
    {
        _playerController.SetInput(_input);
    }
}