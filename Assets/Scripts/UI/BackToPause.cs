using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToPause : MonoBehaviour
{
    public void Click()
    {
        if (PlayerPrefs.GetString("currentSceneName") == "Level1" || PlayerPrefs.GetString("currentSceneName") == "Level 2")
            PlayerPrefs.SetInt("toPause", 1);
        else PlayerPrefs.SetInt("toPause", 0);
        SceneManager.LoadScene(PlayerPrefs.GetString("currentSceneName"));
    }
}
