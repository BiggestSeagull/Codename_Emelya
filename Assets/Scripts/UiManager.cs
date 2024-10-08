using UnityEngine;
using UnityEngine.UI;
using TMPro;
using YG;

public class UiManager : MonoBehaviour
{
    private PuzzleManager PM;


    // UI slider for movement
    public Slider moveSlider;

    // While in the game collected wood show
    [SerializeField] private TextMeshProUGUI currentWood;

    // After score is counted show this
    [SerializeField] private GameObject EndgameUi;
    [SerializeField] private GameObject NewScore;
    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private TextMeshProUGUI bestScore;
    [SerializeField] private Button newGame;

    // Puzzle menu UI
    [SerializeField] private Button openPuzzleMenu;
    [SerializeField] private Button closePuzzleMenu;
    [SerializeField] private Button nextPuzzle;
    [SerializeField] private Button prevPuzzle;


    // Start is called before the first frame update
    void Start()
    {
        PM = GetComponent<PuzzleManager>();

        currentWood.text = "Дрова: \n" + PlayerStats.currentFuel.ToString();

        // To ensure correct state
        EndgameUi.SetActive(false);
        NewScore.SetActive(false);

        // Buttons
        nextPuzzle.onClick.AddListener(delegate { PM.NextPuzzle(); });
        prevPuzzle.onClick.AddListener(delegate { PM.PrevPuzzle(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnEnable()
    {
        GameManager.OnGameEnded += EndGame;

        moveSlider.onValueChanged.AddListener(GameManager.StartGame);
    }
    private void OnDisable()
    {
        GameManager.OnGameEnded -= EndGame;

        moveSlider.onValueChanged.RemoveListener(GameManager.StartGame);
    }

    // Prevent SceneManager.StartGame multiple call
    public void SliderRemoveListener()
    {
        moveSlider.onValueChanged.RemoveListener(GameManager.StartGame);
    }

    public void WoodUpdate()
    {
        currentWood.text = "Дрова: \n" + PlayerStats.currentFuel.ToString();
    }

    // Endgame UI
    public void EndGame()
    {
        moveSlider.gameObject.SetActive(false);

        // End game screen
        EndgameUi.SetActive(true);
        NewScore.SetActive(GameManager.IsNeedToShowNewScore());
        currentScore.text = "Счет: \n" + GameManager.thisGameScore.ToString();
        bestScore.text = "Лучший: \n WIP YA games" + GameManager.tempUntillNoYaGames.ToString();
    }


}
