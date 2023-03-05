using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class Maintenance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*foreach (var hit in Physics2D.OverlapCircleAll(transform.position, 0)) {
            //print("Drag success");
            if (hit.GetComponent<InventoryItem>()?.item?.type == Item.ItemType.CarJack) {
                print("Drag success");
                transform.parent = hit.gameObject.transform;
                return;
            }
        }*/
    }

    private void OnCollisionEnter(Collision collision) {
        /*if (collision.GetComponent<InventoryItem>()?.item?.type == Item.ItemType.CarJack) {
            print("SUCCESS");
        }*/
        print("success");
    }
}
