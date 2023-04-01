using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyCounter : MonoBehaviour
{
    private TMP_Text t;

    void Start()
    {
        t = GetComponent<TMP_Text>();    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            StateController.money += 100;
        } else if (Input.GetKeyDown(KeyCode.R)) {
            StateController.money -= 100;
        }
        t.text = string.Format("${0}", StateController.money);
    }
}
