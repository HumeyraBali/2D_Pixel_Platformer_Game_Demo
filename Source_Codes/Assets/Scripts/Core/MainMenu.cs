using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Reference to the event manager
    public EventManager eventManager;

    // Reference to the UI buttons
    [SerializeField] public Button playButton;
    [SerializeField] public Button quitButton;

    void Start()
    {
        // Add listeners to the buttons
        playButton.onClick.AddListener(OnPlayButtonClick);
        quitButton.onClick.AddListener(OnQuitButtonClick);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnPlayButtonClick();
        }
    }

    void OnPlayButtonClick()
    {
        // Trigger the start game event
        // eventManager.StartGame();
        
        // Load Scene0 (main gameplay scene)
        SceneManager.LoadScene("Level1");
    }

    void OnQuitButtonClick()
    {
        // Quit the application
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //Exits play mode
        #endif
    }
}