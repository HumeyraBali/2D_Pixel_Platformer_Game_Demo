using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerState playerState = new PlayerState();

    public PlayerState GetPlayerState()
    {
        return playerState;
    }

    public void SetPlayerState(PlayerState state)
    {
        playerState = state;
        // Update abilities based on state
        UpdateAbilities();
    }

    void UpdateAbilities()
    {
        // Example of updating abilities based on player state
        if (playerState.canWallJump)
        {
            // Enable wall jump ability
        }
        else
        {
            // Disable wall jump ability
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WallJumpSkill"))
        {
            playerState.canWallJump = true;
            // Destroy the skill object after acquiring it
            Destroy(collision.gameObject);
        }
    }
}

