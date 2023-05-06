using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour {
   
    //loads next scene in build
    public void LoadNextScene() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //loads next scene after victory
    public void ContinueAfterVictory() {

        //goes to next scripted scene if story mode
        if (MainMenu.isStoryMode) {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else {
            SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
        }
    }

    //reloads scene
    public void ReloadScene() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
