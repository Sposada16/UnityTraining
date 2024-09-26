using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;       // Reference to the player's Transform
    public Vector3 offset;         // Offset of the camera from the player (includes Z value for distance)
    public float smoothSpeed = 0.125f;  // Speed at which the camera follows the player
    public float cameraTiltAngle = 15f; // Tilt angle of the camera (how much it looks down)

    void LateUpdate()
    {
        // Calculate the desired position of the camera based on the player's position + offset
        Vector3 desiredPosition = player.position + offset;

        // Smoothly move the camera to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Set the camera's tilt angle to always look at the player with a fixed tilt
        Quaternion fixedRotation = Quaternion.Euler(cameraTiltAngle, 0, 0);
        transform.rotation = fixedRotation;
    }
}
