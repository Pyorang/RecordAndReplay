using UnityEngine;

public class MoveCommand : ReplayCommand
{
    private float input;
    
    public  MoveCommand(PlayerController playerController, float input, float time)
    {
        this.playerController = playerController;
        this.input = input;
        this.time = time;
    }

    public override void Execute()
    {
        playerController.input = input;
    }
}
