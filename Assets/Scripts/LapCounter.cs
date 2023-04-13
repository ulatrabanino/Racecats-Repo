using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LapCounter : MonoBehaviour
{
    public int lapsToComplete = 2;
    public int lapsCompleted = 0;

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            lapsCompleted++;
            
            if (lapsCompleted == lapsToComplete) {
                // watch this video to add delay https://www.youtube.com/watch?v=HZ1hS0zJ5N4
                SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
                StateController.money += 200;
            }
        }
    }
}
