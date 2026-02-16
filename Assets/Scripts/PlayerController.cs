using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //TODO: add flip, add rotation, add jump
    private Rigidbody2D rb;

    [Header("Configuration")]
    [SerializeField] private float jumpHeight;

    private InputAction flip;
    private InputAction jump;

    [Header("Debug")]
    [SerializeField] bool hasFlipped;
    [SerializeField] bool hasJumped;

    private void Jump()
    {
        if (hasJumped || hasFlipped) return;
        hasJumped = true;
        //print("Jump!");

        //sqrt(2 * gravity acceleration * height) gets us the velocity needed to hit jump height
        //well in theory... in practice it position seems to be off by a couple hundreths and there isn't much i can really do about it
        float initialVelocity = (float)Math.Sqrt(2 * (-Physics.gravity.y * Math.Abs(rb.gravityScale)) * jumpHeight);
        int gravityFlip = rb.gravityScale < 0 ? -1 : 1;
        rb.AddForce(new Vector2(0, initialVelocity * gravityFlip), ForceMode2D.Impulse);
    }

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
        if (jump.IsPressed())
            Jump();

        //Debug for jump height
        /*if (lastPos != null && transform.position.y >= originalPos.y + jumpHeight) print("Reached jump height!");
        lastPos = transform.position;*/
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
