using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public void SaveValue()
    {
        PlayerPrefs.SetFloat("volume", gameObject.GetComponent<Slider>().value);
    }
}
