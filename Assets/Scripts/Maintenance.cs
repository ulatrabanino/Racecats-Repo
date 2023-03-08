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
    public Sprite woodBlockSprite;

    // Start is called before the first frame update
    void Start()
    {
        //keeps track of which item needs to be dragged to car
        itemOrder = new[] { Item.ItemType.WoodBlock, Item.ItemType.CarJack, Item.ItemType.Tire };
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    //called when item is dropped on car
    public bool checkDraggedObject(GameObject obj) {
        Item.ItemType itemType = obj.GetComponent<InventoryItem>().item.type;
        
        if(index < itemOrder.Length && itemType == itemOrder[index]) {
            switch(itemType) {

                //positions wood block behind rear wheel
                case Item.ItemType.WoodBlock:
                    obj.transform.position = new Vector3(560f, 285.5f, 0);
                    //gameObject.GetComponent<UnityEngine.UI.Image>().sprite = woodBlockSprite;
                    //NEED TO POSITION BLOCK BASED ON CAR POSITION
                    break;

                //positions car jack under car frame and raises car
                case Item.ItemType.CarJack:
                    obj.transform.position = new Vector3(1095, 383, 0);
                    transform.Rotate(0, 0, 3);
                    transform.SetAsLastSibling();
                    break;
            }
            index++;
            return true;
        }

        return false;
    }
}
