using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Start()
    {
        playerHealth = FindObjectOfType<Health>();
        if(playerHealth != null)
        {
            totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
        }
        else
        {
            Debug.LogError("Player Health not found!");
        }
    }
    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}