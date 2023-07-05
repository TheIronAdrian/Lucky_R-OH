using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movers2 : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float cron;
    public static int endTime2;
    float rand;
    private void Start()
    {
        rand = Random.Range(6f, 9f);
    }
    private void Update()
    {
        if (oprire2.stop == 0)
        {
            rb.velocity = new Vector2(0, -15);
            cron += Time.deltaTime;
            if (cron > rand)
                endTime2 = 1;
        }
        else rb.velocity = new Vector2(0, 0);
    }
}
