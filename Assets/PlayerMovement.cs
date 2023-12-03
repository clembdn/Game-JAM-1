using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private bool isJumping = false;
    public bool isGrounded = false;
    private bool isCrouched = false;
    private bool isFight = false;
    private bool isSlide = false;
    private float verticalSpeed;
    public Transform groundCheckL;
    public Transform groundCheckR;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckL.position, groundCheckR.position);
    
        float horizontalmove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            isJumping = true;
        }

        if(Input.GetKey(KeyCode.S))
        {
            isCrouched = true;
        }
        else
        {
            isCrouched = false;
        }

        if(Input.GetKey(KeyCode.F))
        {
            isFight = true;
        }
        else
        {
            isFight = false;
        }
        if(Input.GetKey(KeyCode.C))
        {
            isSlide = true;
        }
        else
        {
            isSlide = false;
        }

        moveplayer(horizontalmove);
        verticalSpeed = rb.velocity.y;
        flip(rb.velocity.x);
        animator.SetFloat("verticalSpeed", rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isCrouched", isCrouched);
        animator.SetBool("isFight", isFight);
        animator.SetBool("isSlide", isSlide);
    }

    void moveplayer(float _horizontalmove)
    {
        Vector3 targetvelocity = new Vector2(_horizontalmove, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetvelocity, ref velocity, .05f);

        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }
    void flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
