using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;

    private bool warningShown = false; // Keeps track if the warning was already displayed

    // Update is called once per frame
    void Update()
    {
        if (target != null) // Check if the target is not null
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
            warningShown = false; // Reset if the target is valid again
        }
        else if (!warningShown) // Show warning only once
        {
            Debug.LogWarning("CameraFollow: Player is dead! Respawning the player.");
            StartCoroutine(ClearWarningFlagAfterDelay());
        }
    }

    IEnumerator ClearWarningFlagAfterDelay()
    {
        warningShown = true; // Set the flag to prevent duplicate warnings
        yield return new WaitForSeconds(3f);
        warningShown = false; // Allow logging again after the delay
    }
}
