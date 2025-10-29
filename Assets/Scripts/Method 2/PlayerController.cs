using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int moveSpeed = 1;
    public int jumpForce = 1;
    public int rotateSpeed = 1;
    public bool onGround = false;

    public float input;
    private Vector2 inputVec;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(input * moveSpeed, rb.linearVelocity.y);

        if (!onGround)
        {
            transform.Rotate(Vector3.back * input * rotateSpeed * Time.deltaTime);
        }
    }

    public void ActionMove(InputAction.CallbackContext context)
    {
        if(ReplayManager2.instance.currentState != ReplayManager2.State.PlayBack)
        {
            if (context.performed || context.canceled)
            {
                input = context.ReadValue<float>();

                ReplayManager2.instance.commandList.Add(new MoveCommand(this, input, ReplayManager2.instance.currentTime));
            }
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }

    public void ActionJump(InputAction.CallbackContext context)
    {
        if(ReplayManager2.instance.currentState != ReplayManager2.State.PlayBack)
        {
            if (context.performed && onGround)
            {
                Jump();

                ReplayManager2.instance.commandList.Add(new JumpCommand(this, ReplayManager2.instance.currentTime));
            }
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
}
