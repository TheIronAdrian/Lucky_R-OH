using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEnding : MonoBehaviour
{
    [SerializeField] private PlayerCollision col;

    void Start()
    {
        col.collisionEnterPortal += () => SceneManager.LoadScene("EndingScene");
    }
}
