using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class PuzzleManager : MonoBehaviour
{
    // Instead of making duplicates
    [System.Serializable]
    public class Puzzle
    {
        public string name;
        public GameObject parent;
        public GameObject[] tiles;
        public bool[] isTileAcquired = new bool[6];
    }

    [SerializeField] private Puzzle[] puzzles; // Creating

    private int currentPuzzleIndex = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Yandex
    // Подписываемся на событие GetDataEvent в OnEnable
    private void OnEnable() => YandexGame.GetDataEvent += GetData;

    // Отписываемся от события GetDataEvent в OnDisable
    private void OnDisable() => YandexGame.GetDataEvent -= GetData;

    public void GetData()
    {
        // Init all tiles on start
        LoadTileStates();
    }
    #endregion

    // Switch to the next puzzle with UI button
    public void NextPuzzle()
    {
        currentPuzzleIndex = (currentPuzzleIndex + 1) % puzzles.Length;
        SwitchPuzzle(currentPuzzleIndex);
    }

    public void PrevPuzzle()
    {
        currentPuzzleIndex = (currentPuzzleIndex - 1 + puzzles.Length) % puzzles.Length;
        SwitchPuzzle(currentPuzzleIndex);
    }

    // Switch puzzle
    private void SwitchPuzzle(int targetPuzzleIndex)
    {
        // Disable neighboring puzzles
        puzzles[targetPuzzleIndex -1].parent.SetActive(false);
        puzzles[targetPuzzleIndex + 1].parent.SetActive(false);


        Puzzle currentPuzzle = puzzles[targetPuzzleIndex];              // Getting current puzzle
        currentPuzzle.parent.SetActive(true);                           // Enabling parent gameObject
        bool[] isTileAcquired = IsTilesAcquired(currentPuzzle.name);    // Understanding which tiles are acquired
        
        int i = 0;  // Counter, max value = 6
        foreach (GameObject tile in currentPuzzle.tiles)    // Iterating tiles of puzzle
        {
            tile.SetActive(isTileAcquired[i]);              // Enabling tile gameObject if it`s got
            i++;                                            // Counter +1
        }
    }

    // Check are tiles acquired
    private bool[] IsTilesAcquired(string setName)
    {
        switch (setName)
        {
            case "balalaika":
                return YG_Saves.LoadBalalaika();
            case "broomstick":
                return YG_Saves.LoadBroomstick();
            case "door":
                return YG_Saves.LoadDoor();
            case "handkerchief":
                return YG_Saves.LoadHandkerchief();
            case "holder":
                return YG_Saves.LoadHolder();
            case "ledder":
                return YG_Saves.LoadLedder();
            case "rug":
                return YG_Saves.LoadRug();
            default:
                Debug.LogError("Wrong puzzle set name");
                return new bool[6];
        }
    }

    // Load start states of tiles
    private void LoadTileStates()
    {
        foreach (var puzzle in puzzles)
        {
            puzzle.isTileAcquired = IsTilesAcquired(puzzle.name);
        }
    }
}
