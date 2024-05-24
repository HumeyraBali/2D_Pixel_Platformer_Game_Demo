using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    [SerializeField] private AudioClip levelSound;
    private PlayerMovement playerMovement;

   private void OnTriggerEnter2D(Collider2D collision) 
   {
        if (collision.tag == "Player")
        {
            StartCoroutine(WaitAndLoadNextLevel());
        }
   }
   IEnumerator WaitAndLoadNextLevel()
    {
        yield return new WaitForSeconds(3f);
        LoadNextLevel();
    }

    void LoadNextLevel()
    {
        SoundManager.instance.PlaySound(levelSound);
        new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Level2");
    }
}


