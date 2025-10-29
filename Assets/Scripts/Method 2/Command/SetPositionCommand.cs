using Unity.VisualScripting;
using UnityEngine;

public class SetPositionCommand : ReplayCommand
{
    private Vector3 position;

    public SetPositionCommand(PlayerController playerController, Vector3 position, float time)
    {
        this.playerController = playerController;
        this.position = position;
        this.time = time;
    }

    public override void Execute()
    {
        playerController.gameObject.transform.position = position;
    }
}
