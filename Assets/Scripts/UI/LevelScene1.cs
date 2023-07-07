using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScene1 : MonoBehaviour
{
    public void Click()
    {
        PlayerPrefs.SetInt("playerScore", 0);
        SceneManager.LoadScene("Level1");
    }
}
