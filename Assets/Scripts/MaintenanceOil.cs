using UnityEngine;
using UnityEngine.EventSystems;

public class MaintenanceOil : MonoBehaviour, IPointerDownHandler {

    private int index;

    public GameObject carUndersideCanvas;
    public GameObject carHoodCanvas;

    public GameObject carJack;

    // Start is called before the first frame update
    void Start() {
        index = 0;
    }

    // Update is called once per frame
    void Update() {

    }

    //called when item is dropped on car
    public bool CheckDraggedObject(GameObject obj) {

        //positions car jack under car frame and raises car
        carJack.SetActive(true);
        transform.Rotate(0, 0, 3);
        transform.SetAsLastSibling();
        index++;
        return true;
    }

    public void OnPointerDown(PointerEventData eventData) {

        //changes to car underside canvas after car is jacked
        if(index == 1) {
            index++;
            gameObject.transform.parent.gameObject.SetActive(false);
            carUndersideCanvas.SetActive(true);
        }

        //changes to car hood canvas after the underside is complete
        else if(index == 2) {
            gameObject.transform.parent.gameObject.SetActive(false);
            carHoodCanvas.SetActive(true);
        }
    }
}
