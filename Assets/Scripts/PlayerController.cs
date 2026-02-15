using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //TODO: add flip, add rotation, add jump

    private Rigidbody2D rb;

    private InputAction flip;
    private InputAction jump;

    [SerializeField] bool hasFlipped;
    [SerializeField] bool hasJumped;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        flip = InputSystem.actions.FindAction("Player/Flip");
        jump = InputSystem.actions.FindAction("Player/Jump");

    }

    void Update()
    {
        if (flip.WasPressedThisDynamicUpdate() && !hasFlipped)
        {
            //invert player gravity
            rb.gravityScale *= -1;
            hasFlipped = true;
        }
        if (jump.IsPressed() && !hasJumped)
        {
            print("jump");
            hasJumped = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            //reset hasFlipped and hasJumped once player touches floor
            hasFlipped = false;
            hasJumped = false;
        }
    }
}
