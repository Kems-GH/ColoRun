using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovementScript;
    private void OnTriggerEnter2D(Collider2D other)
    {
        playerMovementScript.SetIsOnGround(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerMovementScript.SetIsOnGround(false);
    }
}
