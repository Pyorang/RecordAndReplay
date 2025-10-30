using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private PlayerController _controller;

    public void ActionMove(InputAction.CallbackContext context)
    {
        if (ReplayManager.s_instance.CurrentState != ReplayManager.State.PlayBack)
        {
            if (context.performed || context.canceled)
            {
                _controller.SetInput(context.ReadValue<float>());

                if (ReplayManager.s_instance.CurrentState == ReplayManager.State.Recording)
                    ReplayManager.s_instance.CommandList.Add(new PlayerMoveCommand(_controller, ReplayManager.s_instance.CurrentTime));
            }
        }
    }

    public void ActionJump(InputAction.CallbackContext context)
    {
        if (ReplayManager.s_instance.CurrentState != ReplayManager.State.PlayBack)
        {
            if (context.performed && _controller.OnGround)
            {
                _controller.Jump();

                if (ReplayManager.s_instance.CurrentState == ReplayManager.State.Recording)
                    ReplayManager.s_instance.CommandList.Add(new PlayerJumpCommand(_controller, ReplayManager.s_instance.CurrentTime));
            }
        }
    }
}
