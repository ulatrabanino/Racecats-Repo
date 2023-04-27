using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class prettyButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler 
{
    public GameObject button;
    public GameObject subImage;

    void Start() {
        subImage.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        button.GetComponent<Image>().color = new Color32(255, 235, 122, 255);
        subImage.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData) {
        button.GetComponent<Image>().color = new Color32(255, 235, 122, 0);
        subImage.SetActive(false);
    }
}
