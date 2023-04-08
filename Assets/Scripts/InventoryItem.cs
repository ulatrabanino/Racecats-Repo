using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler {

    //tracks music
    AudioManager manager;

    [Header("UI")]
    public Image image;

    public Item item;
    [HideInInspector] public Transform parentAfterDrag;

    public GameObject car;

    public void Start() {
        manager = FindObjectOfType<AudioManager>();
    }

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

    //checks for collision with car on item drop; depends on canvas
    public void OnEndDrag(PointerEventData eventData) {

        bool destroy = false;

        foreach (var hit in Physics2D.OverlapCircleAll(transform.position, 90)) {
            if (hit.CompareTag("MaintenanceTire")) {
                destroy = car.GetComponent<MaintenanceTire>().CheckDraggedObject(gameObject);
                break;
            }
            else if (hit.CompareTag("MaintenanceOil")) {
                destroy = car.GetComponent<MaintenanceOil>().CheckDraggedObject(gameObject);
                break;
            }
            else if (hit.CompareTag("MaintenanceUnderside")) {
                destroy = car.GetComponent<MaintenanceUnderside>().CheckDraggedObject(gameObject);
                break;
            }
            else if (hit.CompareTag("MaintenanceHood")) {
                destroy = car.GetComponent<MaintenanceHood>().CheckDraggedObject(gameObject);
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
    
    //plays hover sfx and highlights item
    public void OnPointerEnter(PointerEventData eventData) {
        var tempColor = image.color;
        tempColor.a = 0.835f;
        image.color = tempColor;

        manager.Play("ItemHoverSFX");
    }

    public void OnPointerExit(PointerEventData eventData) {
        var tempColor = image.color;
        tempColor.a = 1f;
        image.color = tempColor;
    }
}
