using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Maintenance : MonoBehaviour
{
    private Item.ItemType[] itemOrder;
    private int index;
    public GameObject tire;
    public GameObject woodBlock;
    public GameObject carJack;

    // Start is called before the first frame update
    void Start()
    {
        //keeps track of which item needs to be dragged to car
        itemOrder = new[] { Item.ItemType.WoodBlock, Item.ItemType.CarJack, Item.ItemType.Tire, Item.ItemType.Hubcap };
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public int GetIndex() {
        return index;
    }

    //called when item is dropped on car
    public bool CheckDraggedObject(GameObject obj) {
        Item.ItemType itemType = obj.GetComponent<InventoryItem>().item.type;
        
        if(index < itemOrder.Length && itemType == itemOrder[index]) {
            switch(itemType) {

                //positions wood block behind rear wheel
                case Item.ItemType.WoodBlock:
                    woodBlock.SetActive(true);
                    break;

                //positions car jack under car frame and raises car
                case Item.ItemType.CarJack:
                    carJack.SetActive(true);
                    transform.Rotate(0, 0, 3);
                    transform.SetAsLastSibling();
                    tire.transform.position += new Vector3(15.27f, 20.6f, 0);
                    tire.transform.SetAsLastSibling();
                    break;
                
                //attaches new tire if old tire is removed
                case Item.ItemType.Tire:
                    if(!tire.activeSelf) {
                        tire.GetComponent<Tire>().AttachNewTire();
                    } else {
                        return false;
                    }
                    break;

                //attaches new hubcap if new tire is present
                case Item.ItemType.Hubcap:
                    if(tire.GetComponent<UnityEngine.UI.Image>().sprite.name == "tireNoHubcap") {
                        tire.GetComponent<Tire>().AttachHubcap();
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
}
