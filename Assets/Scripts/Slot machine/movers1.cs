using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movers1 : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float cron;
    public static int endTime1;
    float rand;
    private void Start()
    {
        rand = Random.Range(3f, 6f);
    }
    private void Update()
    {
        if (oprire1.stop == 0)
        {
            rb.velocity = new Vector2(0, -15);
            cron += Time.deltaTime;
            if (cron > rand)
                endTime1 = 1;
        }
        else rb.velocity = new Vector2(0, 0);
    }
}
