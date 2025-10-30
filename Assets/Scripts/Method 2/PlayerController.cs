using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    private float _input;
    private Vector2 _inputVec;

    public int MoveSpeed = 1;
    public int JumpForce = 1;
    public int RotateSpeed = 1;
    public bool OnGround = false;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidBody.linearVelocity = new Vector2(_input * MoveSpeed, _rigidBody.linearVelocity.y);

        if (!OnGround)
        {
            transform.Rotate(Vector3.back * _input * RotateSpeed * Time.deltaTime);
        }
    }

    public float GetInput()
    {
        return _input;
    }
    public void SetInput(float input)
    {
        this._input = input;
    }

    public void Jump()
    {
        _rigidBody.AddForce(Vector2.up * JumpForce);
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnGround = false;
        }
    }
}
