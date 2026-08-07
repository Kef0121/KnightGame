using UnityEngine;
using System.Collections;

public class Playe : MonoBehaviour
{

    public float moveForce = 3f;
    public float jumpForce = 10f;

    private bool onGround;
    private int maxJumps = 1;
    private int jumps;

    //GPT generated the portion related to this. idk what it doess, but is necessary for the OverlapCircle section
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
    void fixedUpdate()
    {
        //
        float horizontal = Input.GetAxis("Horizontal");
        Movement(horizontal);

        Jump();

    }
    //Jump mechanic
    void Jump()
    {

        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

    }
    //
    void Movement(float horizontal)
    {

        rb2d.velocity = new Vector2(horizontal, rb2d.velocity.y);

    }
}
