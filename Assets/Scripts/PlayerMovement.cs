using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int jumpForce = 250;
    [SerializeField] private int speed = 5;
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
        if ( (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && (isGrounded || noJump == 1) )
        {
            jump = true;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
    }
    void FixedUpdate()
    {
        if ( jump )
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

    void OnCollisionEnter2D(Collision2D col)
    {
        if ( col.gameObject.tag == "floor" )
        {
            isGrounded = true;
        }
    }
}
