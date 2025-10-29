using UnityEngine;

public class MoveCommand : ICommand
{
    public float time;
    private float input;
    private PlayerController playerController;
    
    public  MoveCommand(PlayerController playerController, float input, float time)
    {
        this.playerController = playerController;
        this.input = input;
        this.time = time;
    }

    public void Execute()
    {
        playerController.input = input;
    }

    public float ReturnTime()
    {
        return time;
    }
}
