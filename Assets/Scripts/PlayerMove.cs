using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Slider moveSlider;
    [SerializeField] private GameObject player;

    // Border positions; left border is getting as -border
    [SerializeField] private Vector3 border = new(6.5f, 0f, 0f);

    private bool exitCourutine; // TODO move to GameMAnager

    // Coroutines variables
    [SerializeField] private float checkPosFrequency = 0.05f;
    private Vector3 posBefore;
    private Vector3 posNow;
    private float turnSpeed;
    public static float normalizedSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountTurnSpeed());

        player.transform.position = new(0f, 0f, 0f);


    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        // Player pos depends on interpolation by slider value and between borders
        player.transform.position = Vector3.Lerp(-border, border, moveSlider.value);
    }

    private IEnumerator CountTurnSpeed()
    {
        while(exitCourutine == false)
        {
            posBefore = player.transform.position;
            yield return new WaitForSecondsRealtime(checkPosFrequency);
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
        StopCoroutine(CountTurnSpeed());
    }
}
