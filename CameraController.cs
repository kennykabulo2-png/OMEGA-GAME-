using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform player; // Reference to the player's transform
    public float distanceFromPlayer = 5.0f; // Distance from the player
    public float height = 2.0f; // Height above the player
    public float damping = 2.0f; // Damping for smooth motion

    private void LateUpdate() {
        if (player != null) {
            // Calculate the desired position
            Vector3 desiredPosition = player.position - player.forward * distanceFromPlayer;
            desiredPosition.y = player.position.y + height;

            // Smoothly move the camera towards the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);

            // Make the camera look at the player
            transform.LookAt(player);
        }
    }
}