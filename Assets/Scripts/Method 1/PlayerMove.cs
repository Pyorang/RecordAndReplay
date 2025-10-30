using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour, IReplayObject
{
    public int moveSpeed = 1;
    public int jumpForce = 1;
    public int rotateSpeed = 1;
    public bool onGround = false;

    private float input;
    private Vector2 inputVec;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputVec = Vector2.zero;
    }

    private void Start()
    {
        ReplayController.instance.Register(this);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(inputVec.x * moveSpeed, rb.linearVelocity.y);

        if (!onGround)
        {
            transform.Rotate(Vector3.back * input * rotateSpeed * Time.deltaTime);
        }
    }

    public void ActionMove(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            input = context.ReadValue<float>();
            inputVec = new Vector2(input, 0);
        }
    }

    public void ActionJump(InputAction.CallbackContext context)
    {
        if (context.performed && onGround)
        {
            rb.AddForce(Vector2.up * jumpForce);
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

    public string GetId()
    {
        return this.name;
    }
    public SnapshotInfo SaveSnapshot()
    {
        PlayerSnapShotInfo playerSnapShotInfo = new PlayerSnapShotInfo()
        {
            id = this.name,
            position = transform.position,
            velocity = rb.linearVelocity,
            rotation = transform.rotation,
            onGround = onGround
        };

        return playerSnapShotInfo;
    }

    public void LoadSnapShot(SnapshotInfo info)
    {   
        PlayerSnapShotInfo playerSnapShotInfo = (PlayerSnapShotInfo)info;
        transform.position = playerSnapShotInfo.position;
        rb.linearVelocity = playerSnapShotInfo.velocity;
        transform.rotation = playerSnapShotInfo.rotation;
        onGround = playerSnapShotInfo.onGround;
    }

}
