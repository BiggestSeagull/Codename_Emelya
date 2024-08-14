using System;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    // UI slider for movement
    [SerializeField] private Slider moveSlider;
    public static event Action OnSliderPressed;

    // Tiles control
    public static int gameLenght = 15;    // Tiles count for lenght of game
    public static float gameSpeedMultiplier = 15f; // Speed of tiles move

    // Endgame management
    public static event Action OnGameEnded;

    // Method for slider. On value changed game will be started
    public void StartGame(float value)
    {
        // Check if there is subscribers and launching
        OnSliderPressed?.Invoke();

        // Unsubscribe to prevert spamming this void
        moveSlider.onValueChanged.RemoveListener(StartGame);
    }
    
    // This called once when need to end the game
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

    private void OnEnable()
    {
        moveSlider.onValueChanged.AddListener(StartGame);
    }
    private void OnDisable()
    {
        moveSlider.onValueChanged.RemoveListener(StartGame);
    }
}
