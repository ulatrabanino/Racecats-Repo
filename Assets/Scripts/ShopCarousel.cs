using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopCarousel : MonoBehaviour {
    private int spriteNum = 4;
    public Image image;
    public int i = 0;
    public Sprite[] sprites = new Sprite[4];

    public GameObject costObject;
    private TMP_Text costText;

    public GameObject buyButton;

    private int[] prices = new int[4] { 200, 200, 100, 100 };

    void Start() {
        image.sprite = sprites[i];
        costText = costObject.GetComponent<TMP_Text>();
        costText.text = string.Format("Cost: ${0}", prices[i]);

        buyButton.SetActive(!StateController.shopItemsBought[i]);
        costObject.SetActive(!StateController.shopItemsBought[i]);
    }
    
    public void ImageChangeLeft() {
        if ((i - 1) < 0) {
            i = spriteNum;
        }
        image.sprite = sprites[--i];
        costText.text = string.Format("Cost: ${0}", prices[i]);
        
        buyButton.SetActive(!StateController.shopItemsBought[i]);
        costObject.SetActive(!StateController.shopItemsBought[i]);
    }
    public void ImageChangeRight() {
        if ((i + 1) >= spriteNum) {
            i = -1;
        }
        image.sprite = sprites[++i];
        costText.text = string.Format("Cost: ${0}", prices[i]);

        buyButton.SetActive(!StateController.shopItemsBought[i]);
        costObject.SetActive(!StateController.shopItemsBought[i]);
    }

    public void buy() {
        if(StateController.money < prices[i]) {
            return;
        }

        switch(i) {
            case 0:
                if (StateController.carsUnlocked[1]) {
                    StateController.cars[2] = "BlueCarNoWheels";
                    StateController.carsUnlocked[2] = true;
                } else {
                    StateController.cars[1] = "BlueCarNoWheels";
                    StateController.carsUnlocked[1] = true;
                }
                StateController.ownedCarsNum++;
                break;
            case 1:
                if (StateController.carsUnlocked[1]) {
                    StateController.cars[2] = "GreenCarNoWheels";
                    StateController.carsUnlocked[2] = true;
                } else {
                    StateController.cars[1] = "GreenCarNoWheels";
                    StateController.carsUnlocked[1] = true;
                }
                StateController.ownedCarsNum++;
                break;
            case 2:
                if (StateController.wheelsUnlocked[1]) {
                    StateController.wheels[2] = "GreenWheel";
                    StateController.wheelsUnlocked[2] = true;
                } else {
                    StateController.wheels[1] = "GreenWheel";
                    StateController.wheelsUnlocked[1] = true;
                }
                StateController.ownedWheelsNum++;
                break;
            case 3:
                if (StateController.wheelsUnlocked[1]) {
                    StateController.wheels[2] = "BlueWheel";
                    StateController.wheelsUnlocked[2] = true;
                } else {
                    StateController.wheels[1] = "BlueWheel";
                    StateController.wheelsUnlocked[1] = true;
                }
                StateController.ownedWheelsNum++;
                break;
            default:
                Debug.Log("Out of range in shop carousel");
                break;
        }
        StateController.shopItemsBought[i] = true;
        StateController.money -= prices[i];

        buyButton.SetActive(!StateController.shopItemsBought[i]);
        costObject.SetActive(!StateController.shopItemsBought[i]);
    }
}

