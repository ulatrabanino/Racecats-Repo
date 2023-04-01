using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject car;

    void Start()
    {
        SpriteRenderer spriteRenderer = car.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = StateController.carSprite;
    }
}
