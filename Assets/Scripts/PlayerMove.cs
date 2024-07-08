using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Slider moveSlider;
    [SerializeField] private GameObject player;

    // Border positions; left border is getting as -border
    [SerializeField] private Vector3 border = new(6.5f, 0f, 0f);

    // Coroutines variables
    [SerializeField] private float checkPosFrequency = 0.05f;
    private Vector3 posBefore;
    private Vector3 posNow;
    private float turnSpeed;
    public static float normalizedSpeed; // Also used in PlayerAnim.cs


    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }
    private void OnEnable()
    {
        StartCoroutine(CountTurnSpeed());
    }
    private void OnDisable()
    {
        StopCoroutine(CountTurnSpeed());
    }

    private void PlayerMovement()
    {
        // Player pos depends on interpolation by slider value and between borders
        player.transform.position = Vector3.Lerp(-border, border, moveSlider.value);
    }

    private IEnumerator CountTurnSpeed()
    {
        while(true)
        {
            posBefore = player.transform.position;
            yield return new WaitForSeconds(checkPosFrequency);
            posNow = player.transform.position;

            // Turn direction
            if (posNow.x < posBefore.x)
            {
                // Left
                normalizedSpeed = -Mathf.Clamp(turnSpeed, 0f, 10f);
            }
            else
            {
                // Right
                normalizedSpeed = Mathf.Clamp(turnSpeed, 0f, 10f);
            }

            // Turn speed
            turnSpeed = Vector3.Distance(posBefore, posNow);
            yield return null; // Wait for the next frame
        }
    }
}
