using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UIElements;

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
                case Item.ItemType.WoodBlock:
                    GameObject newSprite = new GameObject("Wood Block");

                    //Attach a SpriteRenender to the newly created gameobject
                    SpriteRenderer rend = newSprite.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;

                    //Assign the sprite to the SpriteRenender
                    rend.sprite = woodBlockSprite;
                    newSprite.layer = LayerMask.NameToLayer("UI");
                    newSprite.transform.localScale = new Vector3(10, 10, 10);
                    newSprite.transform.position = new Vector2(1955, 1360.5f);
                    break;
            }
            index++;
            return true;
        }

        return false;
    }
}
