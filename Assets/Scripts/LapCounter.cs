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

                StateController.money += 200;

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                //goes to next scripted scene if story mode
                if (MainMenu.isStoryMode) {
                    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
                } else {
                    SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
                }
            }
        }
    }
}
