using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5.0f;
    private float jumpForce = 5.0f;
    private float horizontalInput;

    private bool isOnGround = true;

    private Rigidbody2D rb;

    [SerializeField] private Transform groundTrigger;

    private void Awake()
    {
        TryGetComponent(out rb);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); // A/D, Left/Right

        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            // Jump
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.Instance.RestartLevel();
        }
    }

    void FixedUpdate()
    {
        isOnGround = Physics2D.IsTouchingLayers(groundTrigger.GetComponent<Collider2D>(), LayerMask.GetMask("Ground"));
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }

    public void SetIsOnGround(bool isGrounded)
    {
        isOnGround = isGrounded;
    }
}
