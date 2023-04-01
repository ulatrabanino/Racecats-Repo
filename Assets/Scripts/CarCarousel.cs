using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarCarousel : MonoBehaviour {
    private int spriteNum = 3;
    public Image image;
    public int i = 0;
    public Sprite[] sprites = new Sprite[3];

    void Start() {
        image.sprite = sprites[0];
    }
    
    public void ImageChangeLeft() {
        if ((i - 1) < 0) {
            i = spriteNum;
        }
        image.sprite = sprites[--i];
    }
    public void ImageChangeRight() {
        if ((i + 1) >= spriteNum) {
            i = -1;
        }
        image.sprite = sprites[++i];
    }

    public void SelectCar(GameObject carImage) {
        Image i = carImage.GetComponent<Image>();
        string color = i.sprite.name.Split("Car")[0];

        StateController.carColor = color;
        StateController.carSprite = Resources.Load(string.Format("{0}Car{1}Wheels", StateController.carColor, StateController.wheelColor), typeof(Sprite)) as Sprite;
    }
}
