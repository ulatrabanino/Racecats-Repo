using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelCarousel : MonoBehaviour {
    public Image image;
    public int i = 0;

    void Start() {
        image.sprite = Resources.Load(StateController.wheels[0], typeof(Sprite)) as Sprite;
    }
    
    public void ImageChangeLeft() {
        if ((i - 1) < 0) {
            i = StateController.ownedWheelsNum;
        }
        image.sprite = Resources.Load(StateController.wheels[--i], typeof(Sprite)) as Sprite;
    }
    public void ImageChangeRight() {
        if ((i + 1) >= StateController.ownedWheelsNum) {
            i = -1;
        }
        image.sprite = Resources.Load(StateController.wheels[++i], typeof(Sprite)) as Sprite;
    }

    public void SelectWheel(GameObject wheelImage) {
        Image i = wheelImage.GetComponent<Image>();
        string color = i.sprite.name.Split("Wheel")[0];

        StateController.wheelColor = color;
        StateController.carSprite = Resources.Load(string.Format("{0}Car{1}Wheels", StateController.carColor, StateController.wheelColor), typeof(Sprite)) as Sprite;
    }
}

