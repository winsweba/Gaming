using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    private Rigidbody2D rb;
    private float moveInput;
    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;


    public Transform grondPos;
    // Start is called before the first frame update
    /* void Start()
     {
         extraJumps = extraJumpsValue;
         rb = GetComponent<Rigidbody2D>();
     }

     // Update is called once per frame
     void FixedUpdate()
     {
         isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
         moveInput = Input.GetAxis("Horizontal");
         rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

         if(facingRight == false && moveInput > 0)
         {
             Flip();
         }
         else if(facingRight == true && moveInput < 0)
         {
             Flip();
         }
     }

     void Update()
     {
         if(isGrounded == true)
         {
             extraJumps = extraJumpsValue;
         }
         if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps >0)
         {
             rb.velocity = Vector2.up * jumpForce;
             extraJumps--;
         }
         else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
         {
             rb.velocity = Vector2.up * jumpForce;
         }
     }
     void Flip()
     {
         facingRight = !facingRight;
         Vector3 Scaler = transform.localScale;
         Scaler.x *= -1;
         transform.localScale = Scaler;
     }*/


    public Joystick joystick;

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = joystick.Horizontal;
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Update()
    {
         float jumpInput = joystick.Vertical;
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }
        if (jumpInput > 0.5f && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (jumpInput > 0.5f && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
