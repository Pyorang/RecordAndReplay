using UnityEngine;

public class JumpCommand : ReplayCommand
{
    public JumpCommand(PlayerController playerController, float time)
    {
        this.playerController = playerController;
        this.time = time;
    }

    public override void Execute()
    {
        playerController.Jump();
    }
}
