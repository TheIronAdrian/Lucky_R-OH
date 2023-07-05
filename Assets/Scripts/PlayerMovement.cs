using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BoxCastDrawer
{
    public static void Draw(
        RaycastHit2D hitInfo,
        Vector2 origin,
        Vector2 size,
        float angle,
        Vector2 direction,
        float distance = Mathf.Infinity)
    {

        Vector2[] originalBox = CreateOriginalBox(origin, size, angle);

        Vector2 distanceVector = GetDistanceVector(distance, direction);
        Vector2[] shiftedBox = CreateShiftedBox(originalBox, distanceVector);


        Color castColor = hitInfo ? Color.red : Color.green;
        DrawBox(originalBox, castColor);
        DrawBox(shiftedBox, castColor);
        ConnectBoxes(originalBox, shiftedBox, Color.gray);

        if (hitInfo)
        {
            Debug.DrawLine(hitInfo.point, hitInfo.point + (hitInfo.normal.normalized * 0.2f), Color.yellow);
        }
    }

    public static RaycastHit2D BoxCastAndDraw(
        Vector2 origin,
        Vector2 size,
        float angle,
        Vector2 direction,
        float distance = Mathf.Infinity,
        int layerMask = Physics2D.AllLayers,
        float minDepth = -Mathf.Infinity,
        float maxDepth = Mathf.Infinity)
    {
        var hitInfo = Physics2D.BoxCast(origin, size, angle, direction, distance, layerMask, minDepth, maxDepth);
        Draw(hitInfo, origin, size, angle, direction, distance);
        return hitInfo;
    }

    private static Vector2[] CreateOriginalBox(Vector2 origin, Vector2 size, float angle)
    {
        float w = size.x * 0.5f;
        float h = size.y * 0.5f;
        Quaternion q = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));

        var box = new Vector2[4]
        {
            new Vector2(-w, h),
            new Vector2(w, h),
            new Vector2(w, -h),
            new Vector2(-w, -h),
        };

        for (int i = 0; i < 4; i++)
        {
            box[i] = (Vector2)(q * box[i]) + origin;
        }

        return box;
    }

    private static Vector2[] CreateShiftedBox(Vector2[] box, Vector2 distance)
    {
        var shiftedBox = new Vector2[4];
        for (int i = 0; i < 4; i++)
        {
            shiftedBox[i] = box[i] + distance;
        }

        return shiftedBox;
    }

    private static void DrawBox(Vector2[] box, Color color)
    {
        Debug.DrawLine(box[0], box[1], color);
        Debug.DrawLine(box[1], box[2], color);
        Debug.DrawLine(box[2], box[3], color);
        Debug.DrawLine(box[3], box[0], color);
    }

    private static void ConnectBoxes(Vector2[] firstBox, Vector2[] secondBox, Color color)
    {
        Debug.DrawLine(firstBox[0], secondBox[0], color);
        Debug.DrawLine(firstBox[1], secondBox[1], color);
        Debug.DrawLine(firstBox[2], secondBox[2], color);
        Debug.DrawLine(firstBox[3], secondBox[3], color);
    }

    private static Vector2 GetDistanceVector(float distance, Vector2 direction)
    {
        if (distance == Mathf.Infinity)
        {
            float sceneWidth = Camera.main.orthographicSize * Camera.main.aspect * 2f;
            distance = sceneWidth * 5f;
        }

        return direction.normalized * distance;
    }
}


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int jumpForce = 250;
    [SerializeField] private int speed = 5;
    [SerializeField] private float raycastDistance = 5;
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
            Debug.Log("Is grounded");
            noJump = 0;
        }

        if ( (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && (IsGrounded() || noJump == 1) )
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

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(collider2d.bounds.center, collider2d.bounds.size - new Vector3(0.1f, 0, 0), 0, Vector2.down, raycastDistance, (1 << 3));
        return (hit.collider != null && hit.collider.gameObject.tag == "floor");
    }
}
