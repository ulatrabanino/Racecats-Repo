using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //tracks music
    AudioManager manager;
    void Start() {
        manager = FindObjectOfType<AudioManager>();
        manager.Play("MainMenuBGM");
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame() {
        SceneManager.LoadSceneAsync("Racetrack", LoadSceneMode.Single);
    }

    public void PlayMenuSFX() {
        manager.Play("MainMenuHoverSFX");
    }

    public void QuitGame() {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
