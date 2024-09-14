using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillGainDash : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the PlayerMovement script from the player GameObject
            PlayerControl playerControl = other.GetComponent<PlayerControl>();
            
            // Grant the double jump skill if the player movement script is found
            if (playerControl != null)
            {
                playerControl.EnableDash();
                
                // destroy the item after the player collects it
                Destroy(gameObject);
            }
        }
    }
}
