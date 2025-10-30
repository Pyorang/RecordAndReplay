using UnityEngine;

public class PlayerJumpCommand : RecordedCommand
{
    private PlayerController _playerController;

    public PlayerJumpCommand(PlayerController playerController, float time)
    {
        this._playerController = playerController;
        this._time = time;
    }

    public override void Execute()
    {
        _playerController.Jump();
    }
}