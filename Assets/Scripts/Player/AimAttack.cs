using UnityEngine;
using UnityEngine.InputSystem;

public class AimAttack : MonoBehaviour
{
    private Camera mainCamera;
    private Vector2 mousePosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (PauseMenu.GamePaused)
            return;

        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        Vector2 direction = mouseWorldPosition - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Debug.DrawLine(transform.position, mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue()),Color.red);
    }
}
