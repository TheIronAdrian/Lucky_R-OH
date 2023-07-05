using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int jumpForce = 400;
    [SerializeField] private int speed = 4;
    [SerializeField] private float raycastDistance = 0.1f;
    [SerializeField] private float sidewaysDistance = 0.4f;
    private bool jump = false;
    private Rigidbody2D rb;
    private BoxCollider2D collider2d;
    private int noJump = 0;

    [SerializeField] private AudioSource boing;
    [SerializeField] private AudioSource doubleBoing;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (IsGrounded())
        {
            //Debug.Log("Is grounded");
            noJump = 0;
        }

        if ( (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && (IsGrounded() || noJump == 1) )
        {
            jump = true;
        }
        else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !closeToSideways(-1))
        {
            transform.rotation = Quaternion.Euler(0, 180 ,0);
            transform.position += Vector3.left * Time.deltaTime * speed;
        }
        else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && !closeToSideways(1))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
    }
    void FixedUpdate()
    {
        if ( jump )
        {
            Debug.Log($"Jumping {noJump}");
            if (noJump == 1)
            {
                //  Double jump
                doubleBoing.Play();
                rb.velocity = Vector3.zero;
            }
            rb.AddForce(new Vector2(0, jumpForce));

            boing.Play();

            jump = false;
            //isGrounded = false;
            noJump ++;
        }
    }

    bool closeToSideways(int dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(collider2d.bounds.center, Vector2.right * dir, sidewaysDistance, (1 << 3));
        Debug.Log(hit.collider);
        return (hit.collider != null && hit.collider.gameObject.tag == "floor");
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(collider2d.bounds.center, collider2d.bounds.size - new Vector3(0.1f, 0, 0), 0, Vector2.down, raycastDistance, (1 << 3));
        return (hit.collider != null && hit.collider.gameObject.tag == "floor");
    }
}
