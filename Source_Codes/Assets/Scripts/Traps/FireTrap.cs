using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [Header("FireTrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    [SerializeField] private float damage;
    [SerializeField] private AudioClip firesound;
    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered; // when the trp is triggered
    private bool active; // when the trap is active and can hurt the player

    private void Awake() 
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player")
        {
            if (!triggered)
            {
                //trigger the FireTrap
                StartCoroutine(ActivateFireTrap());
            }
            if (active)
                collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private IEnumerator ActivateFireTrap()
    {
        // turn the sprite red and trigger the trap
        triggered = true;
        spriteRend.color = Color.red;

        // Wait for a delay, active trap, turn on animation, return color back to normal
        yield return new WaitForSeconds(activationDelay);
        active = true;
        spriteRend.color = Color.white;
        SoundManager.instance.PlaySound(firesound);
        anim.SetBool("activated",true);

        //Wait until x seconds deactivate trap and reset all variables and animator
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated",false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // If the trap is active and the player is still colliding with it, deal damage
        if (collision.CompareTag("Player") && active)
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

}
