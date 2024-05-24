using UnityEngine;

public class QuitGameOnEscape : MonoBehaviour
{
    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Quit the application
            Application.Quit();
                    
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; //Exits play mode
            #endif
        }
    }
}

