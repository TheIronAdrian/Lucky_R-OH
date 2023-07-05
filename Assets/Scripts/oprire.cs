using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class oprire : MonoBehaviour
{
    [SerializeField] BoxCollider2D bc;
    public static int stop;
    float tmp;
    private void Start()
    {
        stop = 2;
    }
    // Update is called once per frame
    void Update()
    {
        if(movers.endTime == 1)
        {
            tmp += Time.deltaTime;
            if (tmp > 0.2)
                bc.enabled = true;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.position.y > 0.03f)
                stop = 1;
    }

}
