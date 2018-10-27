using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public float speed;
    public float movetime;
    public float jumpSpeed;
    bool isJumping;
    bool isGrounded;

    Rigidbody2D rb;
    private float horizontal;
    Vector2 refernce;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        refernce = Vector2.zero;
    }

    // Update is called once per frame
    void Update() {
        horizontal = Input.GetAxisRaw("Horizontal");
        isJumping = Input.GetButtonDown("Jump");
    }

    private void FixedUpdate()
    {
        Vector2 targetvelocity = new Vector2(speed * horizontal, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetvelocity, ref refernce, movetime);
        if (isJumping)
        {
            isJumping = false;
            if (isGrounded)
            {
                Jump();
            }
        }
        isGrounded = false;
        Collider2D[] beneath = Physics2D.OverlapBoxAll(
            new Vector2(transform.position.x, transform.position.y - 0.05f),
            new Vector2(transform.localScale.x -0.1f,transform.localScale.y),
            0.0f
             );
        foreach ( Collider2D c in beneath)
        {
            if (c.gameObject.CompareTag("Floor"))
            {
                isGrounded = true;
            }
            
        }

    }

   private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
    }


}
