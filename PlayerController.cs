using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform coverPosition;
    private bool isTakingCover = false;

    void Update()
    {
        HandleMovement();
        HandleCover();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        transform.Translate(movement.normalized * moveSpeed * Time.deltaTime);
    }

    private void HandleCover()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCover();
        }
    }

    private void ToggleCover()
    {
        isTakingCover = !isTakingCover;
        if (isTakingCover)
        {
            transform.position = coverPosition.position;
            // Additional logic to change the player's state to cover
        }
        else
        {
            // Logic to exit cover state
        }
    }
}