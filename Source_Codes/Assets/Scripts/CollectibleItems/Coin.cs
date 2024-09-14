using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip coincollect;
    // Reference to the UI Text displaying the total number of coins
    public TMP_Text[] coinText;
    public static int totalCoins = 0;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the coin collides with the player
        //Debug.Log("Collided with coin");
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(coincollect);
            totalCoins++;
            
            //Debug.Log("Total coins: " + totalCoins);
            UpdateCoinUI();

            // Destroy the coin GameObject
            Destroy(gameObject);
        }
    }
    void UpdateCoinUI()
    {
        foreach (TMP_Text text in coinText)
        {
            text.text = totalCoins.ToString();
        }
    }
}
