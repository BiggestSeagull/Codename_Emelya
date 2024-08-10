using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private GameObject firstTile;
    [SerializeField] private GameObject[] possibleTiles;
    [SerializeField] private float speedMultiplier;

    private Vector3 firstPos = new(0f, -1.7f, 0f);
    private bool isGameStarted;

    // Start is called before the first frame update
    void Start()
    {
        SetFirstTile();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStarted)
        {
            MoveTiles();

        }
    }

    // Sub/unsub on player interaction with move slider
    private void OnEnable()
    {
        SceneManager.OnSliderPressed += GameHasStarted;
    }
    private void OnDisable()
    {
        SceneManager.OnSliderPressed -= GameHasStarted;
    }

    private void GameHasStarted()
    {
        // Enable Update()
        isGameStarted = true;
    }


    private void SetFirstTile()
    {
        Instantiate(firstTile, firstPos, Quaternion.identity, transform);
        
        SetNextTile();
        SetNextTile();
        SetNextTile();
    }

    private void SetNextTile()
    {
        // Getting position for new tile
        Vector3 _afterLastPos = transform.GetChild(transform.childCount - 1).position;
        _afterLastPos.z += 30f;

        // Trying to flip tile by 180 degrees
        if (TryFlip(50) == true) 
        {
            // To flip creating new vector and transforming to Quaternion with Quaternion.Euler
            Vector3 targetedRotation = new (0f, 180f, 0f);
            GameObject _newTile = Instantiate(possibleTiles[Random.Range(0, possibleTiles.Length)], _afterLastPos, Quaternion.Euler(targetedRotation), transform);
        }
        else
        {
            GameObject _newTile = Instantiate(possibleTiles[Random.Range(0, possibleTiles.Length)], _afterLastPos, Quaternion.identity, transform);
        }
            
    }

    private bool TryFlip(int chanceToFlip)
    {
        int randomValue = Random.Range(0, 101);

        if (chanceToFlip >= randomValue) return true;
        else return false;
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
