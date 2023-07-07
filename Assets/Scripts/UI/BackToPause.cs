using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToPause : MonoBehaviour
{
    public void Click()
    {
        SceneManager.LoadScene("UITrying");
    }
}
