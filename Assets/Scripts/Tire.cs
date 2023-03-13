using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tire : MonoBehaviour, IPointerDownHandler {

    public GameObject car;
    public Sprite tireDamagedNoHubcap;
    public Sprite tireNoHubcap;
    public Sprite tire;

    //removes hubcap and tire on click
    public void OnPointerDown(PointerEventData eventData) {
        if(car.GetComponent<MaintenanceTire>().GetIndex() == 2) {
            if (gameObject.GetComponent<Image>().sprite.name == "tireDamagedNoHubcap") {
                gameObject.SetActive(false);
            }
            else {
                gameObject.GetComponent<Image>().sprite = tireDamagedNoHubcap;
            }
        }
    }

    //attaches new tire sprite
    public void AttachNewTire() {
        gameObject.GetComponent<Image>().sprite = tireNoHubcap;
        gameObject.SetActive(true);
    }

    //attaches new hubcap sprite
    public void AttachHubcap() {
        gameObject.GetComponent<Image>().sprite = tire;
    }
}
