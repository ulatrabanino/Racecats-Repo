using UnityEngine;
using UnityEngine.EventSystems;

public class MaintenanceHood : MonoBehaviour, IPointerDownHandler {

    //tracks music
    AudioManager manager;

    private Item.ItemType[] itemOrder;
    private int index;

    public Sprite carHood;
    public Sprite carHoodNoCap;
    public Sprite carHoodFunnel;
    public Sprite carHoodFunnelOil;

    public GameObject capInventorySlot;

    // Start is called before the first frame update
    void Start() {
        //keeps track of which item needs to be dragged to car
        itemOrder = new[] { Item.ItemType.Funnel, Item.ItemType.Oil, Item.ItemType.Cap };
        index = 0;

        manager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update() {

    }

    public int GetIndex() {
        return index;
    }

    //called when item is dropped on hood
    public bool CheckDraggedObject(GameObject obj) {
        Item.ItemType itemType = obj.GetComponent<InventoryItem>().item.type;

        if (index < itemOrder.Length && itemType == itemOrder[index]) {
            switch (itemType) {

                //puts funnel in oil container
                case Item.ItemType.Funnel:
                    if (gameObject.GetComponent<UnityEngine.UI.Image>().sprite.name == "carHoodNoCap") {
                        gameObject.GetComponent<UnityEngine.UI.Image>().sprite = carHoodFunnel;
                    }
                    else {
                        return false;
                    }
                    break;

                //pours oil in funnel
                case Item.ItemType.Oil:
                    if (gameObject.GetComponent<UnityEngine.UI.Image>().sprite.name == "carHoodFunnel") {
                        gameObject.GetComponent<UnityEngine.UI.Image>().sprite = carHoodFunnelOil;
                    }
                    else {
                        return false;
                    }
                    break;

                //puts cap on oil container
                case Item.ItemType.Cap:
                    if (gameObject.GetComponent<UnityEngine.UI.Image>().sprite.name == "carHoodNoCap") {
                        gameObject.GetComponent<UnityEngine.UI.Image>().sprite = carHood;

                        manager.Play("MaintenanceCompleteSFX");
                    }
                    else {
                        return false;
                    }
                    break;

                default:
                    break;
            }
            index++;
            return true;
        }
        return false;
    }

    public void OnPointerDown(PointerEventData eventData) {
        switch (index) {

            //removes oil cap at beginning of sequence
            case 0:
                gameObject.GetComponent<UnityEngine.UI.Image>().sprite = carHoodNoCap;
                capInventorySlot.SetActive(true);
                break;

            //removes funnel after oil is poured
            case 2:
                gameObject.GetComponent<UnityEngine.UI.Image>().sprite = carHoodNoCap;
                break;

            default:
                break;
        }
    }
}