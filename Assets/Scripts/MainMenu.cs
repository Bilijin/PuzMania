using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private AudioManager audioManager;
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Effects").GetComponent<AudioManager>();
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenLevelSelectScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelTypeSelect");
        audioManager.PlayAud();
    }

   public void OpenHelpScreen()
   {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Help");
        audioManager.PlayAud();
   }

    public void OpenAboutScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("About");
        audioManager.PlayAud();
    }

    public void PlayRandomLevel()
    {

    }

    public void OpenSettings()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Settings");
        audioManager.PlayAud();
    }

    public void OpenCredits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
        audioManager.PlayAud();
    }

    public void GoBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        audioManager.PlayAud();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
