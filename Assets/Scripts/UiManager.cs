using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UiManager : MonoBehaviour
{
    // UI slider for movement
    public Slider moveSlider;

    // While in the game collected wood show
    [SerializeField] private TextMeshProUGUI currentWood;

    // After score is counted show this
    [SerializeField] private GameObject EndgameUi;

    // Start is called before the first frame update
    void Start()
    {
        currentWood.text = "Дрова: \n" + PlayerStats.currentFuel.ToString();

        // To ensure correct state
        EndgameUi.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        SceneManager.OnGameEnded += EndGame;

        moveSlider.onValueChanged.AddListener(SceneManager.StartGame);
    }
    private void OnDisable()
    {
        SceneManager.OnGameEnded -= EndGame;

        moveSlider.onValueChanged.RemoveListener(SceneManager.StartGame);
    }

    // Prevent SceneManager.StartGame multiple call
    public void SliderRemoveListener()
    {
        moveSlider.onValueChanged.RemoveListener(SceneManager.StartGame);
    }

    public void WoodUpdate()
    {
        currentWood.text = "Дрова: \n" + PlayerStats.currentFuel.ToString();
    }

    // Endgame UI
    public void EndGame()
    {
        EndgameUi.SetActive(true);
        moveSlider.gameObject.SetActive(false);
    }
}
