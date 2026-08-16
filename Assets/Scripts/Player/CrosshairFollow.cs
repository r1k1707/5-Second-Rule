using UnityEngine;
using UnityEngine.InputSystem;

public class CrosshairFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float distanceFromPlayer = 3f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (PauseMenu.GamePaused)
            return;

        // Get mouse position using the New Input System
        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();

        // Convert screen position to world position
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0f;

        // Get direction from player to mouse
        Vector3 direction = mouseWorldPosition - player.position;

        // Prevent issues if mouse is exactly on player
        if (direction.sqrMagnitude > 0.001f)
        {
            direction.Normalize();

            // Keep crosshair a fixed distance from player
            transform.position = player.position + direction * distanceFromPlayer;
        }
    }
}