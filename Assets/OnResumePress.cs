using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnResumePress : MonoBehaviour
{
    [SerializeField] PlayerMovement player;
    public void OnResumePressFunction()
    {
        Debug.Log("AA");
        player.Unpause();
    }
}
