using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    public GameObject slider; 
    public void OnValueChanged() {
        AudioListener.volume = slider.GetComponent<Slider>().value;
    }
}
