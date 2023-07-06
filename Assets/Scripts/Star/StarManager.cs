using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarManager : MonoBehaviour
{
    [SerializeField] private Star star;
    [SerializeField] private PlayerCollision col;

    bool isEnterPressed, isCollided;

    void Start()
    {
        isCollided = false;
        isEnterPressed = false;
        col.collisionEnterStar += () => UpdateIsCollided(true);
        col.enterDown += () => UpdateIsEnterPressed(true);
        col.collisionExitStar += () => UpdateIsCollided(false);
        col.enterUp += () => UpdateIsEnterPressed(false);
    }
    void UpdateIsCollided(bool val)
    {
        Debug.Log("iscollided " + val);
        isCollided = val;
    }
    void UpdateIsEnterPressed(bool val)
    {
        Debug.Log("isenterpressed " + val);
        isEnterPressed = val;
    }
    void Update()
    {
        if (isCollided && isEnterPressed)
        {
            SceneManager.LoadScene("pacanelescene");
            star.DestroyStar();
        }
    }
}
