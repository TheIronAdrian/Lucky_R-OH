using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oprire1 : MonoBehaviour
{
    [SerializeField] BoxCollider2D bc;
    float tmp;
    public static int stop = 1;
    // Update is called once per frame
    void Update()
    {
        if (movers1.endTime1 == 1)
        {
            tmp += Time.deltaTime;
            if(tmp > 0.2)
               bc.enabled = true;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.transform.position.y > 0.03f)
            stop = 1;
    }
}
