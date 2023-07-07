using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnSettingsPress : MonoBehaviour
{
    public void OnSettingsPressFunction()
    {
        PlayerPrefs.SetString("currentSceneName", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Settings");
    }
}
