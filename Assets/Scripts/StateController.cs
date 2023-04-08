using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public static Sprite carSprite;
    public static string carColor;
    public static string wheelColor;
    public static int money;

    public static bool[] carsUnlocked = new bool[3] { true, false, false };
    public static bool[] wheelsUnlocked = new bool[3] { true, false, false };
    public static string[] cars = new string[3] { "RedCarNoWheels", "", "" };
    public static string[] wheels = new string[3] { "BlackWheel", "", "" };
    public static int ownedCarsNum = 1;
    public static int ownedWheelsNum = 1;

    void Start() {
        carSprite = Resources.Load("RedCarBlackWheels", typeof(Sprite)) as Sprite;
        money = 0;
    }
}
