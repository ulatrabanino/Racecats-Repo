using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Security.Cryptography;
using Unity.VisualScripting;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;

    public Item item;
    [HideInInspector] public Transform parentAfterDrag;

    public GameObject car;
    public void InitializeItem(Item newItem) {
        item = newItem;
        image.sprite = newItem.image;
    }
    public void OnBeginDrag(PointerEventData eventData) {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    //checks for collision with car on item drop
    public void OnEndDrag(PointerEventData eventData) {
        bool destroy = false;
        foreach (var hit in Physics2D.OverlapCircleAll(transform.position, 90)) {
            if (hit.CompareTag("MaintenanceCar")) {
                destroy = car.GetComponent<Maintenance>().CheckDraggedObject(gameObject);
                break;
            }
        }

        //destroy object if no longer needed
        if (destroy) {
            Destroy(gameObject);
            return;
        }

        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }
}
