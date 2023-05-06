using UnityEngine;
using UnityEngine.SceneManagement;

public class LapCounter : MonoBehaviour
{
    //tracks player laps
    public int lapsToComplete = 2;
    public int lapsCompleted = 0;

    //tracks enemy racer laps
    public int lapsToCompleteEnemyRacer = 2;
    public int lapsCompletedEnemyRacer = 0;

    public int lapsToCompleteEnemyRacer2 = 2;
    public int lapsCompletedEnemyRacer2 = 0;

    //screens to display after loss/victory
    public GameObject tryAgainCanvas;
    public GameObject victoryCanvas;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            lapsCompleted++;
            
            if (lapsCompleted == lapsToComplete) {
                // watch this video to add delay https://www.youtube.com/watch?v=HZ1hS0zJ5N4

                StateController.money += 200;

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                DisableEnemyRacers();
                victoryCanvas.SetActive(true);
            }
        }

        else if (other.CompareTag("EnemyRacer")) {
            lapsCompletedEnemyRacer++;

            if (lapsCompletedEnemyRacer == lapsToCompleteEnemyRacer) {
                Cursor.lockState = CursorLockMode.None;
                DisableEnemyRacers();
                tryAgainCanvas.SetActive(true);
            }
        }

        else if (other.CompareTag("EnemyRacer2")) {
            lapsCompletedEnemyRacer2++;

            if (lapsCompletedEnemyRacer2 == lapsToCompleteEnemyRacer2) {
                Cursor.lockState = CursorLockMode.None;
                DisableEnemyRacers();
                tryAgainCanvas.SetActive(true);
            }
        }
    }

    private void DisableEnemyRacers() {
        Scene currentScene = SceneManager.GetActiveScene();

        // Iterate through all the root game objects in the scene
        foreach (GameObject rootGameObject in currentScene.GetRootGameObjects()) {
            // Disable the game object and all its children
            GameObject objToDisable = GameObject.Find("EnemyRacer");
            if (objToDisable != null) {
                objToDisable.SetActive(false);
            } else {
                GameObject objToDisable2 = GameObject.Find("EnemyRacer2");
                if (objToDisable2 != null) {
                    objToDisable2.SetActive(false);
                }
            }

        }
    }
}
