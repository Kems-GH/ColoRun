using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5.0f;
    private float jumpForce = 5.0f;
    private float horizontalInput;

    private bool isOnGround = true;

    private Rigidbody2D rb;

    [SerializeField] private Timer timer;

    private void Awake()
    {
        TryGetComponent(out rb);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.pause) return;

        horizontalInput = Input.GetAxis("Horizontal"); // A/D, Left/Right

        if(!timer.isRunning && horizontalInput != 0)
        {
            timer.StartTimer();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.Instance.RestartLevel();
        }
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.pause) return;
        float jumpVelocity = rb.velocity.y;

        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.3f, LayerMask.GetMask("Ground"));
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector2(0.40f, 0.40f), 0, Vector2.down, 0.05f, LayerMask.GetMask("Ground"));
        isOnGround = hit.collider != null;
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && isOnGround)
        {
            // Jump
            jumpVelocity = jumpForce;
        }

        rb.velocity = new Vector2(horizontalInput * speed, jumpVelocity);
    }

    public void SetIsOnGround(bool isGrounded)
    {
        isOnGround = isGrounded;
    }
}
