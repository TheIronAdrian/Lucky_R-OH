using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class teleportare : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider)
    {
        collider.gameObject.transform.position = new Vector3(collider.gameObject.transform.position.x, collider.gameObject.transform.position.y + 11, collider.gameObject.transform.position.z);
        
    }
}
