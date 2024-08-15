using System;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static event Action OnSliderPressed;

    // Tiles control
    public static int gameLenght = 5;    // Tiles count for lenght of game
    public static float gameSpeedMultiplier = 15f; // Speed of tiles move

    // Endgame management
    public static event Action OnGameEnded;
    public static int thisGameScore; // Counted in EndgameScore

    // Method for slider. On value changed game will be started
    public static void StartGame(float value)
    {
        // Check if there is subscribers and launching
        OnSliderPressed?.Invoke();

        // Unsubscribe to prevert spamming this void
        GameObject.FindGameObjectWithTag("SceneManager").GetComponent<UiManager>().SliderRemoveListener();
    }
    
    // This called once when need to end the game. Now it`s ends after scoring
    public static void EndGame()
    {
        OnGameEnded?.Invoke();

        // Eg of trigger

        //private void OnEnable()
        //{
        //    SceneManager.OnGameEnded += egGameHasEnded;
        //}
        //private void OnDisable()
        //{
        //    SceneManager.OnGameEnded -= egGameHasEnded;
        //}
    }
}
