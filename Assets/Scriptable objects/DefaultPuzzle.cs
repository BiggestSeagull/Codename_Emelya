using UnityEngine;

[CreateAssetMenu(fileName = "DefaultPuzzle", menuName = "ScriptableObjects/DefaultPuzzle", order = 1)]
public class SpawnManagerScriptableObject : ScriptableObject
{
    public string puzzleName;

    public int tilesCount;
    public bool[] isTilesCollected;

    public void EnableCollectedTile()
    {
        if (isTilesCollected == null)
        {

        }

    }
}
