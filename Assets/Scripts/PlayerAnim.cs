using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private float smoothTurn;

    public float duration = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        smoothTurn = Mathf.Lerp(animator.GetFloat("Turn speed"), PlayerMove.normalizedSpeed, duration);

        animator.SetFloat("Turn speed", smoothTurn);
    }
}
