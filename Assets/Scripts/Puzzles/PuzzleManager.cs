using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    // Balalaika
    public GameObject[] balalaikaTiles;
    private bool[] IsBalalaikaGot = new bool[6];

    // Broomstick
    public GameObject broomstickTiles;
    private bool[] IsBroomstickGot = new bool[6];

    // Door
    public GameObject doorTiles;
    private bool[] IsDoorGot = new bool[6];

    // Handkerchief
    public GameObject handkerchiefTiles;
    private bool[] IsHandkerchiefGot = new bool[6];

    // Holder
    public GameObject holderTiles;
    private bool[] IsHolderGot = new bool[6];

    // Ledder
    public GameObject ledderTiles;
    private bool[] IsLedderGot = new bool[6];

    // Rug
    public GameObject rugTiles;
    private bool[] IsRugGot = new bool[6];


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Call this with string of object to check are tile acquired
    private void IsTilesAcquired(string setToCheck)
    {
        switch (setToCheck)
        {
            case "balalaika":
                IsBalalaikaGot = YG_Saves.LoadBalalaika();
                break;
            case "broomstick":
                IsBroomstickGot = YG_Saves.LoadBroomstick();
                break;
            case "door":
                IsDoorGot = YG_Saves.LoadDoor();
                break;
            case "handkerchief":
                IsHandkerchiefGot = YG_Saves.LoadHandkerchief();
                break;
            case "holder":
                IsHolderGot = YG_Saves.LoadHolder();
                break;
            case "ledder":
                IsLedderGot = YG_Saves.LoadLedder();
                break;
            case "rug":
                IsRugGot = YG_Saves.LoadRug();
                break;
        }
    }

}
