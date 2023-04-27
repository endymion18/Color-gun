using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 10f;
    private float horizontal;
    private bool isFacingRight;
    public float jumpForce = 10f;
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    
    void Start()
    {
        
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (isGrounded() && Input.GetKeyDown (KeyCode.W)) 
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}
        else if(!isGrounded() && Input.GetKeyUp (KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate() 
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if (!isFacingRight && horizontal < 0f || isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
        
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); 
    }

}
