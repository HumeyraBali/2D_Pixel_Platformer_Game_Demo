using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [SerializeField] private AudioClip heartcollect;

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(heartcollect);
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}