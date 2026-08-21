using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;

    private Transform player;

    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private string idleStateName = "Bacteria_Idle";

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        anim.Play("Bacteria_Idle");

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        if (player == null)
            return;

        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        // Gets the current animation to play from the base layer
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        // Forcing the AI to drag the Idle back in
        if (!stateInfo.IsName(idleStateName))
        {
            // Forcing the animator to go back to the idle loop instantly
            anim.Play(idleStateName, 0, stateInfo.normalizedTime);
        }
    }
}