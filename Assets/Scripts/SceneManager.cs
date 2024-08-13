using System;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private Slider moveSlider;
    public static event Action OnSliderPressed;
    public static event Action OnEndGame;

    // Method for slider. On value changed game will be started
    public void StartGame(float value)
    {
        // Check if there is subscribers and launching
        OnSliderPressed?.Invoke();

        // Unsubscribe to prevert spamming this 
        moveSlider.onValueChanged.RemoveListener(StartGame);

    }

    public void EndGame()
    {
        OnEndGame?.Invoke();
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
