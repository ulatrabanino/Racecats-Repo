using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler {

    //tracks sfx
    AudioManager manager;

    // Start is called before the first frame update
    void Start() {
        manager = FindObjectOfType<AudioManager>();
    }

    //plays hover sfx
    public void OnPointerEnter(PointerEventData eventData) {
        manager.Play("MainMenuHoverSFX");
    }
}
