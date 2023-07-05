using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int jumpForce = 250;
    [SerializeField] private int speed = 5;
    [SerializeField] private float raycastDistance = 5;
    private bool jump = false;
    private Rigidbody2D rb;
    private bool isGrounded = true;
    private int noJump = 0;

    public AudioSource boing;
    public AudioSource doubleBoing;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if ( (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && (isGrounded || noJump == 1) )
        {
            jump = true;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180 ,0);
            transform.position += Vector3.left * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
    }
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, raycastDistance, (1 << 3));
        if ( jump && (hit.collider != null && hit.collider.gameObject.tag == "floor" || noJump == 1) )
        {
            if( noJump == 1 ) {
                //  Double jump
                doubleBoing.Play();
            }
            rb.AddForce(new Vector2(0, jumpForce));

            boing.Play();

            jump = false;
            isGrounded = false;
            noJump ++;
            if ( noJump == 2 )
            {
                noJump = 0;
            }
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if ( col.gameObject.tag == "floor" )
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "floor")
        {
            isGrounded = false;
        }
    }
}
