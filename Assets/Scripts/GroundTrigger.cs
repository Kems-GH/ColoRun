using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovementScript;
    private int groundCount = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        playerMovementScript.SetIsOnGround(true);
        groundCount++;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        groundCount--;
        groundCount = groundCount < 0 ? 0 : groundCount;
        if (groundCount == 0)
            playerMovementScript.SetIsOnGround(false);

    }
}
