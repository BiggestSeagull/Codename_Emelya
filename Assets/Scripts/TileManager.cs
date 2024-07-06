using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private GameObject[] possibleTiles;
    [SerializeField] private float speedMultiplier;

    private Vector3 firstPos = new(0f, -1.7f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        SetFirstTile();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTiles();
    }

    private void SetFirstTile()
    {
        GameObject _newTile = Instantiate(possibleTiles[Random.Range(0, possibleTiles.Length)], firstPos, Quaternion.identity, transform);
        
        SetNextTile();
        SetNextTile();
        SetNextTile();
    }

    private void SetNextTile()
    {
        Vector3 _afterLastPos = transform.GetChild(transform.childCount - 1).position;
        _afterLastPos.z += 30f;

        GameObject _newTile = Instantiate(possibleTiles[Random.Range(0, possibleTiles.Length)], _afterLastPos, Quaternion.identity, transform);
    }

    private void MoveTiles()
    {
        foreach(Transform tile in transform)
        {
            if (tile != null)
            {
                Vector3 _position = tile.transform.position;
                _position.z -= Time.deltaTime * speedMultiplier;
                tile.transform.position = _position;

                // Destroy if out of sight
                if (tile.transform.position.z <= -30f)
                {
                    Destroy(tile.gameObject);
                    SetNextTile();
                } 
                    
            }
        }
    }
}
