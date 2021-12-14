using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectMenu : MonoBehaviour
{
    private AudioManager audioManager;
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Effects").GetComponent<AudioManager>();
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();
    }

    void Update()
    {
        
    }

    public void OpenRiddleLevels()
    {
        audioManager.PlayButtonPress();
        UnityEngine.SceneManagement.SceneManager.LoadScene("RiddleSelect");
    }

    public void OpenAagramLevels()
    {
        audioManager.PlayButtonPress();
        UnityEngine.SceneManagement.SceneManager.LoadScene("AnagramSelect");
    }

    public void GoBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        audioManager.PlayAud();
    }
}
