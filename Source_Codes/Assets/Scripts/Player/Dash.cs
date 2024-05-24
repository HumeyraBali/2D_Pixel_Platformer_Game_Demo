using UnityEngine;
using System.Collections;

public class Dash : MonoBehaviour
{
    public float dashDistance = 5f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 2f;

    private bool isDashing = false;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            StartCoroutine(Dashing());
        }
    }

    private IEnumerator Dashing()
    {
        isDashing = true;

        // Record current position
        Vector2 startPosition = rb.position;

        // Calculate dash end position
        Vector2 endPosition = startPosition + (Vector2)transform.right * dashDistance;

        // Perform dash movement
        float elapsedTime = 0f;
        while (elapsedTime < dashDuration)
        {
            rb.MovePosition(Vector2.Lerp(startPosition, endPosition, elapsedTime / dashDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure player reaches dash end position
        rb.MovePosition(endPosition);

        // Apply cooldown
        yield return new WaitForSeconds(dashCooldown);

        isDashing = false;
    }
}
