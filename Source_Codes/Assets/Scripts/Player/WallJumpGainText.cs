using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WallJumpGainText : MonoBehaviour
{
    [SerializeField] private GameObject skillGainText;
    [SerializeField] private AudioClip skillGainSound;
    private bool isTextActive = false;

   private void OnTriggerEnter2D(Collider2D collision) 
   {
        if (collision.tag == "Player" &&! isTextActive)
        {
            SoundManager.instance.PlaySound(skillGainSound);
            StartCoroutine(ShowSkillGainText());
            isTextActive = true;
        }
   }
   IEnumerator ShowSkillGainText()
    {
        skillGainText.SetActive(true);
        yield return new WaitForSeconds(1f);
        skillGainText.SetActive(false);
        isTextActive = false;
    }
}
