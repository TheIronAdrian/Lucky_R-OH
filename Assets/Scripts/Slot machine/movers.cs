using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movers : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
   [SerializeField] float cron;
    public static int endTime = 0;
    float rand;
    private void Start()
    {
        rand = Random.Range(1f, 3f);
    }
    private void Update()
    {
        if (oprire.stop == 0)
        {
            rb.velocity = new Vector2(0, -15);
            cron += Time.deltaTime;
            if (cron > rand)
                endTime = 1;
        }
        else if (oprire.stop == 1)
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
