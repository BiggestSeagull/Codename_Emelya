using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSystem : MonoBehaviour
{
    public GameObject[] tiles;
    public bool[] isTileCollected;

    public void Debugging()
    {
        if (tiles.Length != isTileCollected.Length) Debug.LogError("Puzzle tiles and it`s isCollected count not equivalent. Check this object in inspector");
    }
}
