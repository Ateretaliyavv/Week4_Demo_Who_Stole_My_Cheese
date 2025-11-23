using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class MouseMover : MonoBehaviour
{
    [SerializeField] float speed = 2f;        // Mouse movement speed

    private Rigidbody2D rb;
    private Vector2 currentDir = Vector2.right;  // start moving to the right

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        currentDir = Vector2.right;
        rb.linearVelocity = currentDir * speed;
    }

    void FixedUpdate()
    {
        // keep the mouse moving all the time
        rb.linearVelocity = currentDir * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.isTrigger)
            return; // ignore triggers (cheese, traps, players triggers)

        ChooseNewDirection();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.isTrigger)
            return;

        // if still touching a wall – keep trying
        ChooseNewDirection();
    }

    // Choose a new direction perpendicular to the previous one
    void ChooseNewDirection()
    {
        if (Mathf.Abs(currentDir.x) > 0.1f)
        {
            // we were moving horizontally -> choose up or down
            currentDir = Random.value < 0.5f ? Vector2.up : Vector2.down;
        }
        else
        {
            // we were moving vertically -> choose left or right
            currentDir = Random.value < 0.5f ? Vector2.left : Vector2.right;
        }
    }
}
