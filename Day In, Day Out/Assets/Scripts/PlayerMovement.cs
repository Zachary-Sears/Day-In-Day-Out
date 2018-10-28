using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public float speed;
    public float movetime;
    public float jumpSpeed;
    bool isJumping;
    bool isGrounded;
    Sprite normalPosition;
    public Sprite fallPosition;

    public float tripTime;



    bool isOcupied;
    float timeToBeOcupied;
    public GameObject canvas;
    




    Rigidbody2D rb;
    private float horizontal;
    Vector2 refernce;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        refernce = Vector2.zero;
        timeToBeOcupied = 0;
        isOcupied = false;
        normalPosition = gameObject.GetComponent<SpriteRenderer>().sprite;
        
        
    }

    // Update is called once per frame
    void Update() {

        timeToBeOcupied -= Time.deltaTime;
        timeToBeOcupied = Mathf.Max(0, timeToBeOcupied);
        if(timeToBeOcupied==0)
        {
            isOcupied = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = normalPosition;
        }



        if (isOcupied == false)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            isJumping = Input.GetButtonDown("Jump");
        }
        else
        {
            horizontal = 0;
            isJumping = false;
        }
    }

    private void FixedUpdate()
    {
        if(horizontal==-1)
        {
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(-0.1f,0.1f);
          
            gameObject.GetComponent<SpriteRenderer>().flipX=true;
        }
        if (horizontal == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0.1f, 0.1f);
        }

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
            new Vector2(gameObject.GetComponent<BoxCollider2D>().size.x -0.1f, gameObject.GetComponent<BoxCollider2D>().size.y),
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

    public void Trip()
    {
        canvas.GetComponent<UI_Manager>().DecreaseHappiness(50);
        isOcupied = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = fallPosition;
        timeToBeOcupied = tripTime;
        canvas.GetComponent<UI_Manager>().UpdateMessage("You Tripped");
        

    }

    public void Ocupied(Sprite oSprite, float time, string oMessage, float decreseH)
    {
        canvas.GetComponent<UI_Manager>().DecreaseHappiness(decreseH);
        isOcupied = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = oSprite;
        timeToBeOcupied = time;
        canvas.GetComponent<UI_Manager>().UpdateMessage(oMessage);


    }


}
