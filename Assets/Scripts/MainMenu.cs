using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //tracks music
    AudioManager manager;
    public void Start() {
        manager = FindObjectOfType<AudioManager>();
        manager.Play("MainMenuBGM");
    }
    public void PlayGame() {
        SceneManager.LoadScene("Racetrack");
    }

    public void PlayMenuSFX() {
        manager.Play("MainMenuHoverSFX");
    }

    public void QuitGame() {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
