using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndgameScoring : MonoBehaviour
{
    [SerializeField] private UiManager uiManager;

    private void OnDisable()
    {
        StopCoroutine(Scoring());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("StartScoringTrigger"))
        {
            Destroy(other.gameObject);

            StartCoroutine(Scoring());
        }
    }

    private IEnumerator Scoring()
    {
        int playerScore = 0;
        float speed = 0.6f;

        while (PlayerStats.currentFuel > 0)
        {
            PlayerStats.currentFuel -= 1;
            uiManager.WoodUpdate();

            playerScore += 1;

            // Adjust the speed for a more immersive experience
            switch (speed)
            {
                case > 0.4f:
                    speed -= 0.1f; // Decrease speed faster when it's above 0.4
                    break;
                case > 0.2f:
                    speed -= 0.06f; // Decrease speed faster when it's above 0.2
                    break;
                case > 0.06f:
                    speed -= 0.03f; // Decrease speed slower when it's above 0.06
                    break;
            }
            yield return new WaitForSeconds(speed);
        }

        int scoreBonus = Random.Range(9, 21);
        GameManager.thisGameScore = playerScore + scoreBonus;

        // Call UI
        // Send command to activate trigger (event) in SM.cs
        GameManager.EndGame();

        yield return null;
    }

}
