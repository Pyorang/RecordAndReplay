using Unity.VisualScripting;
using UnityEngine;

public class SetPositionCommand : ICommand
{
    public float time;
    private Vector3 position;
    private PlayerController playerController;
    public SetPositionCommand(PlayerController playerController, Vector3 position, float time)
    {
        this.playerController = playerController;
        this.position = position;
        this.time = time;
    }

    public void Execute()
    {
        playerController.gameObject.transform.position = position;
    }

    public float ReturnTime()
    {
        return time;
    }
}
