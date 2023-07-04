using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    public Action collisionEnter;
    public Action enterDown;
    public Action collisionExit;
    public Action enterUp;
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if ( enterDown != null )
                enterDown.Invoke();
        }
        else if(Input.GetKeyUp(KeyCode.Return))
        {
            if ( enterUp != null )
                enterUp.Invoke();
        }
    }
    void OnTriggerExit2D(Collider2D coll) {
        if(coll.gameObject.tag == "bottle") {
            if(collisionExit != null)
                collisionExit.Invoke();
        }
    }
    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.tag == "bottle") {
            if(collisionEnter != null)
                collisionEnter.Invoke();
        }
    }
}
