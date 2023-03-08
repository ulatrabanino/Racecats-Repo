using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCarousel : MonoBehaviour
{
    public Image image;
    public int i = 0;
    public Sprite[] sprites = new Sprite[5];
    
    public void ImageChangeLeft() {
        if ((i - 1) < 0) {
            i = 5;
        }
        image.sprite = sprites[--i];
    }
    public void ImageChangeRight() {
        if ((i + 1) > 4) {
            i = -1;
        }
        image.sprite = sprites[++i];
    }
}
