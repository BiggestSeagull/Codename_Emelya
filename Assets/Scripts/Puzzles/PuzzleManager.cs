using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        // Init all tiles on start
        LoadTileStates(); //FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX FIX запрос до инициализвации sdk
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    // Switch puzzle backend
    private void SwitchPuzzle(int targetPuzzleIndex)
    {
        Puzzle currentPuzzle = puzzles[targetPuzzleIndex];
        bool[] isTileAcquired = IsTilesAcquired(currentPuzzle.name);

        for (int i = 0; i < currentPuzzle.tiles.Length; i++)
        {
            currentPuzzle.tiles[i].SetActive(isTileAcquired[i]);
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
