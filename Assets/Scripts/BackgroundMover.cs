using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] float xOrg;
    [SerializeField] float yOrg;
    [SerializeField] float xOrgPlay;
    [SerializeField] float yOrgPlay;
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] float xMultiplier;
    [SerializeField] float yMultiplier;
    [SerializeField] GameObject player;

    void Update()
    {
        x = player.GetComponent<Transform>().position.x;
        y = player.GetComponent<Transform>().position.y;
        GetComponent<Transform>().localPosition = new Vector3(xOrg + (x - xOrgPlay) * xMultiplier, yOrg + (y - yOrgPlay) * yMultiplier);
    }
}
