using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SpriteRenderer sr;
    void Start()
    {
        sr.sprite.texture.filterMode = FilterMode.Point;

        // Get stuff
        double height = sr.sprite.bounds.size.y;
        double worldScreenHeight = Camera.main.orthographicSize * 2.0;

        // Resize
        transform.localScale = new Vector2(1, 1) * (float)(worldScreenHeight / height);
    }
 /*   void Update()
    {
        
    }*/

}
