using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndgameScoring : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EndGameScoring")
        {
            // Send command to activate trigger (event) in SM.cs
            SceneManager.EndGame();

            Destroy(other.gameObject);
        }
    }

}
