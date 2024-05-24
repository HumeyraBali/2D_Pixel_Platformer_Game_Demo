using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    // Define an event for starting the game
    public UnityEvent onStartGame;

    // Function to invoke the start game event
    public void StartGame()
    {
        onStartGame.Invoke();
    }
}
