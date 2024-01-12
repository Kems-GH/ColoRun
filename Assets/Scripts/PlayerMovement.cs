using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5.0f;
    private float jumpForce = 5.0f;
    private float horizontalInput;

    private bool isOnGround = true;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); // A/D, Left/Right

        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            // Jump
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }

    public void SetIsOnGround(bool isGrounded)
    {
        isOnGround = isGrounded;
    }
}
