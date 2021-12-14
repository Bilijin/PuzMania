using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleLevelSelect : MonoBehaviour
{
    public UnityEngine.UI.Button[] buttons;

    private AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Effects").GetComponent<AudioManager>();
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();
        //PlayerPrefs.SetInt("RiddleMaxLevel", 0);

        PlayerPrefs.SetInt("RiddleCurrentLevel", 0);

        for (int i = 0; i < buttons.Length; i++)
        {
            if (PlayerPrefs.GetInt("RiddleMaxLevel", 0) >= i)
            {
                buttons[i].transform.Find("lock").GetComponent<UnityEngine.UI.Image>().enabled = false;

            }
        }
    }

    void Update()
    {
        
    }

    void LoadLevel(int level)
    {
        audioManager.PlayButtonPress();
        if (PlayerPrefs.GetInt("RiddleMaxLevel", 0) >= level - 1) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("RiddleLevel");
            PlayerPrefs.SetInt("RiddleCurrentLevel", level);
        }
    }

    public void GoBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelTypeSelect");
        audioManager.PlayAud();
    }
}
