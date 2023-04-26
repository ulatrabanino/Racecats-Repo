using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    AudioManager manager;
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public bool notMaintenance = true;

    public GameObject continueButton;

    private void Start()
    {
        manager = FindObjectOfType<AudioManager>();
        manager.Play("StoryBGM");

        StartCoroutine(Type());
    }

    private void Update()
    {
        if (notMaintenance) {
            if (textDisplay.text == sentences[index])
            {
                continueButton.SetActive(true);
            }
        } else {
            if ((textDisplay.text == sentences[index]) && (index != sentences.Length - 1))
            {
                continueButton.SetActive(true);
            }
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
  
    public void NextSentence()
    {
        continueButton.SetActive(false);
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            //goes back to main menu if finished last story cutscene
            if (SceneManager.GetActiveScene().name == "Cutscene4") {
                MainMenu.isStoryMode = false;
                SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
            } 
            
            //else continue to next scene
            else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                textDisplay.text = "";
                continueButton.SetActive(false);
            }
        }
    }
}
