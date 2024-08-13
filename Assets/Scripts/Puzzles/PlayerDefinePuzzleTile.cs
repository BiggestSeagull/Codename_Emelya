using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefinePuzzleTile : MonoBehaviour
{
    private int collectedTiles;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PuzzleBonus")
        collectedTiles += 1;
    }

}
