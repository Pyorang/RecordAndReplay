using UnityEngine;

public class JumpCommand : ICommand
{
    public float time;
    private PlayerController playerController;
    public JumpCommand(PlayerController playerController, float time)
    {
        this.playerController = playerController;
        this.time = time;
    }

    public void Execute()
    {
        playerController.Jump();
    }

    public float ReturnTime()
    {
        return time;
    }
}
