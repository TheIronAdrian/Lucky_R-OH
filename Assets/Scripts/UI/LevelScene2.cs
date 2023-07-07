using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScene2 : MonoBehaviour
{
    public void Click()
    {
        PlayerPrefs.SetInt("playerScore", 0);
        PlayerPrefs.SetInt("noBottles", 0);
        SceneManager.LoadScene("Level 2");
    }
}
