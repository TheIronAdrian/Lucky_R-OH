using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleScoring : MonoBehaviour
{
    public void DestroyBottle()
    {
        Debug.Log("Destroy Bottle");
        Destroy(gameObject);
    }
}
