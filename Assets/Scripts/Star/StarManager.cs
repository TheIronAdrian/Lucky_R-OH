using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarManager : MonoBehaviour
{
    [SerializeField] private Star star;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private PlayerCollision col;

    bool isEnterPressed, isCollided;
    int displayStar = 1;

    void Start()
    {
        isCollided = false;
        isEnterPressed = false;
        displayStar = PlayerPrefs.GetInt("displayStar", 1);
        if (displayStar == 0)
            star.DestroyStar();
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
            player.SavePosition();
            star.DestroyStar();
            PlayerPrefs.SetInt("displayStar", 0);
            SceneManager.LoadScene("pacanelescene");
        }
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("displayStar", 1);
    }
}
