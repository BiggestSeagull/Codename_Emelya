using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private Animator animator;

    //private float smoothTurn;
    //public float duration = 1f;


    private void OnEnable()
    {
        GameManager.OnSliderPressed += GameHasStarted;

        // Animation of rocking on waves used as idle
        animator.SetBool("floating", true);
    }
    private void OnDisable()
    {
        GameManager.OnSliderPressed -= GameHasStarted;
    }

    private void GameHasStarted()
    {

        animator.SetBool("floating", false);
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: try to make turns to look more smooth
        //smoothTurn = Mathf.Lerp(animator.GetFloat("Turn speed"), PlayerMove.normalizedSpeed, duration);

        animator.SetFloat("Turn speed", PlayerMove.normalizedSpeed);
    }
}
