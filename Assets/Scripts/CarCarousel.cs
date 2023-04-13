using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarCarousel : MonoBehaviour {
    public Image image;
    public int i = 0;

    void Start() {
        image.sprite = Resources.Load(StateController.cars[0], typeof(Sprite)) as Sprite;
    }
    
    public void ImageChangeLeft() {
        if ((i - 1) < 0) {
            i = StateController.ownedCarsNum;
        }
        image.sprite = Resources.Load(StateController.cars[--i], typeof(Sprite)) as Sprite;
    }
    public void ImageChangeRight() {
        if ((i + 1) >= StateController.ownedCarsNum) {
            i = -1;
        }
        image.sprite = Resources.Load(StateController.cars[++i], typeof(Sprite)) as Sprite;
    }

    public void SelectCar(GameObject carImage) {
        Image i = carImage.GetComponent<Image>();
        string color = i.sprite.name.Split("Car")[0];

        StateController.carColor = color;
        StateController.carSprite = Resources.Load(string.Format("{0}Car{1}Wheels", StateController.carColor, StateController.wheelColor), typeof(Sprite)) as Sprite;
    }
}
