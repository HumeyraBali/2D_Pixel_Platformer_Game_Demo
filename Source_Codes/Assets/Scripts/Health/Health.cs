using System.Collections;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    [SerializeField] private AudioClip deathsound;
    [SerializeField] private AudioClip hurtsound;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header ("İFrames")]
    [SerializeField] private float İFramesDuration; 
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float _damage)
    {
        //if (invulnerable) return;
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            //anim.SetTrigger("hurt");
            //iframes
            StartCoroutine(Invunerability());
            SoundManager.instance.PlaySound(hurtsound);
            //Debug.Log("" + currentHealth + "");
        }
        else
        {
            if (!dead)
            {
                
                Debug.Log("Game Over");

                GetComponent<PlayerMovement>().enabled = false;
                //deactivate all attached component classes
                //foreach (Behaviour component in components)
                    //component.enabled = false;
                anim.SetBool("grounded",true);
                anim.SetTrigger("die");
                dead = true;
                SoundManager.instance.PlaySound(deathsound);

                //gameOverManager.ShowGameOver(Coin.totalCoins);
 
            }
        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void Respawn()
    {
        dead = false;
        AddHealth(startingHealth);
        anim.ResetTrigger("die");
        anim.Play("idle");
        //StartCoroutine(Invunerability());

        GetComponent<PlayerMovement>().enabled = true;

        //foreach (Behaviour component in components)
            //component.enabled = true;
    }

    int GetTotalCoinsCollected()
    {
        return Coin.totalCoins;
    }

    private IEnumerator Invunerability()
    {
        //invulnerable = true;
        Physics2D.IgnoreLayerCollision(7,8, true);

        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1,0,0,0.5f);
            yield return new WaitForSeconds(İFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(İFramesDuration / (numberOfFlashes * 2));
        }
        
        Physics2D.IgnoreLayerCollision(7,8, false);
        //invulnerable = false;
    }
        private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}