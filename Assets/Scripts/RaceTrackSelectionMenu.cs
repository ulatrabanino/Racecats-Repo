using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceTrackSelectionMenu : MonoBehaviour
{
    public void loadGrasslandRaceTrack() {
        SceneManager.LoadSceneAsync("Racetrack", LoadSceneMode.Single);
    }
    public void loadDesertRaceTrack() {
        SceneManager.LoadSceneAsync("Racetrack 1", LoadSceneMode.Single);
    }
}
