using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levertrigger : MonoBehaviour
{
    [SerializeField] Animator animator;
    int ok;
    private void Start()
    {
        ok = 0;
    }
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        if (ok == 0)
        {
            animator.SetTrigger("spin");
            oprire.stop = 0;
            oprire1.stop = 0;
            oprire2.stop = 0;
            ok = 1;
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (ok == 0)
            {
                animator.SetTrigger("spin");
                oprire.stop = 0;
                oprire1.stop = 0;
                oprire2.stop = 0;
                ok = 1;
            }
        }
    }
}
