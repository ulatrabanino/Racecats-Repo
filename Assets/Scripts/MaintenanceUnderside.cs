using UnityEngine;
using UnityEngine.EventSystems;

public class MaintenanceUnderside : MonoBehaviour, IPointerDownHandler {
    private Item.ItemType[] itemOrder;
    private int index;

    public GameObject mainCanvas;

    public Sprite carUnderside;
    public Sprite carUndersideNoPlug;
    public Sprite carUndersideNoFilter;

    public GameObject plugInventorySlot;

    // Start is called before the first frame update
    void Start() {
        //keeps track of which item needs to be dragged to car
        itemOrder = new[] { Item.ItemType.Plug, Item.ItemType.Filter };
        index = 0;
    }

    // Update is called once per frame
    void Update() {

    }

    public int GetIndex() {
        return index;
    }

    //called when item is dropped on car
    public bool CheckDraggedObject(GameObject obj) {
        Item.ItemType itemType = obj.GetComponent<InventoryItem>().item.type;

        if (index < itemOrder.Length && itemType == itemOrder[index]) {
            switch (itemType) {

                //puts plug back in oil pan
                case Item.ItemType.Plug:
                    if(gameObject.GetComponent<UnityEngine.UI.Image>().sprite.name == "carUndersideNoPlug") {
                        gameObject.GetComponent<UnityEngine.UI.Image>().sprite = carUnderside;
                    } else {
                        return false;
                    }
                    break;

                //puts new filter in oil pan
                case Item.ItemType.Filter:
                    if (gameObject.GetComponent<UnityEngine.UI.Image>().sprite.name == "carUndersideNoFilter") {
                        gameObject.GetComponent<UnityEngine.UI.Image>().sprite = carUnderside;
                    } else {
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
        switch(index) {

            //removes oil pan plug at beginning of sequence
            case 0:
                gameObject.GetComponent<UnityEngine.UI.Image>().sprite = carUndersideNoPlug;
                plugInventorySlot.SetActive(true);
                break;

            //removes old oil filter after oil is drained
            case 1:
                gameObject.GetComponent<UnityEngine.UI.Image>().sprite = carUndersideNoFilter;
                break;

            //returns to main canvas
            case 2:
                gameObject.transform.parent.gameObject.SetActive(false);
                mainCanvas.SetActive(true);
                break;

            default:
                break;
        }
    }
}
