using UnityEngine;
using System.Collections;

public class knight_main : MonoBehaviour
{

    //Jump gizmos
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    private bool onGround;
    private int maxJumps = 1;
    private int Jumps;

    //RigidBody2d
    private Rigidbody2D rb;

    //facing left/right thingies
     

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if grounded
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (onGround)
        {
            Jumps = 0;
        }


        // Move left/right
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);


        // Jump
        if (Jumps < maxJumps && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Jumps++;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
    }
}

