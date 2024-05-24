using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashGainText : MonoBehaviour
{
    [SerializeField] private GameObject skillGainText;
    [SerializeField] private AudioClip skillGainSound;

   private void OnTriggerEnter2D(Collider2D collision) 
   {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(skillGainSound);
            skillGainText.SetActive(true);
            new WaitForSeconds(5f);
            skillGainText.SetActive(false);
        }
   }
}
