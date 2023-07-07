using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void MainMenuSend()
    {
        SceneManager.LoadScene("UITrying");
    }
}
