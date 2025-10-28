using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public int moveSpeed = 1;
    public int jumpForce = 1;
    public Vector2 inputVec;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.position += inputVec * moveSpeed * Time.deltaTime;
    }

    public void ActionMove(InputAction.CallbackContext context)
    {
        if(context.performed || context.canceled)
        {
            float input = context.ReadValue<float>();
            inputVec = new Vector2(input, 0);
        }
    }

    public void ActionJump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            rb.AddForce(new Vector2(0,1) * jumpForce);
        }
    }
}
