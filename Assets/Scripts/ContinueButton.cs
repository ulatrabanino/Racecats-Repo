using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour {
    
    //loads next scene in build
    public void LoadNextScene() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
