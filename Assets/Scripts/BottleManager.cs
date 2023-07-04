using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleManager : MonoBehaviour
{
    [SerializeField] private BottleScoring bottle;
    [SerializeField] private PlayerCollision col;

    bool isEnterPressed, isCollided;
    // Start is called before the first frame update
    void Start()
    {
        isCollided = false;
        isEnterPressed = false;
        col.collisionEnter += () => UpdateIsCollided(true);
        col.enterDown += () => UpdateIsEnterPressed(true);
        col.collisionExit += () => UpdateIsCollided(false);
        col.enterUp += () => UpdateIsEnterPressed(false);
    }
    void UpdateMultiplier()
    {

    }
    void UpdateIsCollided(bool val)
    {
        isCollided = val;
    }
    void UpdateIsEnterPressed(bool val)
    {
        isEnterPressed = val;
    }
    void Update() 
    {
        if ( isCollided && isEnterPressed )
        {
            UpdateMultiplier();
            bottle.DestroyBottle();
        }
    }
}
