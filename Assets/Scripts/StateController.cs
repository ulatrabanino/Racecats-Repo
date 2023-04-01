using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public static Sprite carSprite;
    public static string carColor;
    public static string wheelColor;
    public static int money;

    public bool[] carsUnlocked = new bool[3];
    public bool[] wheelsUnlocked = new bool[3];

    void Start() {
        carSprite = Resources.Load("RedCarBlackWheels", typeof(Sprite)) as Sprite;
        money = 0;
    }
}
