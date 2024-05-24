using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        // Get reference to the event manager
        EventManager eventManager = FindObjectOfType<EventManager>();

        // Add listener for the start game event
        eventManager.onStartGame.AddListener(StartGame);
    }

    void StartGame()
    {
        // Start the game
        Debug.Log("Game Started!");
    }
}
