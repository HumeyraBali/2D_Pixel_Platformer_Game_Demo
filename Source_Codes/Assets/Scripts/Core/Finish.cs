using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject finishScreen;
    [SerializeField] private AudioClip finishSound;

   private void OnTriggerEnter2D(Collider2D collision) 
   {
        if (collision.tag == "Player")
        {
            finishScreen.SetActive(true);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.SetActive(false);    // To prevent the player from being seen behind the scene
            SoundManager.instance.PlaySound(finishSound);
        }
   }
}
