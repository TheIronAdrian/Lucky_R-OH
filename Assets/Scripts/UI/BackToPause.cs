using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToPause : MonoBehaviour
{
    [SerializeField] private VolumeSlider volumeSlider;
    public void Click()
    {
        if (PlayerPrefs.GetString("currentSceneName") == "Level1" || PlayerPrefs.GetString("currentSceneName") == "Level 2")
            PlayerPrefs.SetInt("toPause", 1);
        else PlayerPrefs.SetInt("toPause", 0);
        volumeSlider.SaveValue();
        SceneManager.LoadScene(PlayerPrefs.GetString("currentSceneName"));
    }
}
