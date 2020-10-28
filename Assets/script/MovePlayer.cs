using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform  colRight;
    [SerializeField] private Transform  colLeft;
    public Animator animator;
    public SpriteRenderer spriteRenderer;


    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    //public bool isJumping = false;
    private bool isgrounded;
    public int counter;
    private void FixedUpdate()
    {
        float horizontalMouvent = Input.GetAxis("Horizontal") * speed * Time.deltaTime;



        if (Physics2D.OverlapArea(colLeft.position, colRight.position))
        {
            counter = 0;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (counter == 1)
            {
                counter = 0;
                rb.AddForce(new Vector2(0f, jumpForce));
            }
            if(Physics2D.OverlapArea(colLeft.position, colRight.position))
            {
                counter = 0;
                rb.AddForce(new Vector2(0f, jumpForce));
                counter++;
            }

            //isJumping = true;
            

           
        }


        Vector3 targetVelocity = new Vector2(horizontalMouvent, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("speed",characterVelocity);

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
