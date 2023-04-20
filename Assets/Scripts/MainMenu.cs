using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //tracks music
    AudioManager manager;

    public static bool isStoryMode = false;

    void Start() {
        manager = FindObjectOfType<AudioManager>();
        manager.Play("MainMenuBGM");
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame() {
        isStoryMode = true;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayMenuSFX() {
        manager.Play("MainMenuHoverSFX");
    }

    public void QuitGame() {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
