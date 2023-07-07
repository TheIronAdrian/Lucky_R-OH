using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public void OnValueChanged(float value)
    {
        AudioListener.volume = value;
    }
    private void Awake()
    {
        gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat("volume", 1);
    }
    public void SaveValue()
    {
        PlayerPrefs.SetFloat("volume", gameObject.GetComponent<Slider>().value);
    }
}
