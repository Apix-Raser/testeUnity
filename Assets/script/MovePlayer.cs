using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform  GroundCheck;
    
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public LayerMask collisionLayer;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    //public bool isJumping = false;
    private bool isgrounded;

    private float horizontalMouvent;

    void Update()
    {
        horizontalMouvent = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            if (Physics2D.OverlapCircle(GroundCheck.position, 0.5f,collisionLayer))
            {

                rb.AddForce(new Vector2(0f, jumpForce));
            }
        }

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("speed", characterVelocity);

    }


    void FixedUpdate()
    {

        Vector3 targetVelocity = new Vector2(horizontalMouvent, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

       


        //code qui marche 
        //var hInput = Input.GetAxisRaw("Horizontal");
        //var direction = new Vector3(hInput, 0, transform.position.z)
        //    .normalized;
        //var velocity = Time.deltaTime * speed * direction;
        //transform.position += velocity;

    }

    void Flip(float speed)
    {
        if (speed > 0.1f )
        {

            spriteRenderer.flipX = false;
        }
        if(speed < -0.1f )
        {
            spriteRenderer.flipX = true;
        }
    }

}
