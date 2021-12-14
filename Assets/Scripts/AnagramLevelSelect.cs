using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnagramLevelSelect : MonoBehaviour
{
    public UnityEngine.UI.Button[] buttons;

    private AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Effects").GetComponent<AudioManager>();
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();

        //PlayerPrefs.SetInt("AnagramMaxLevel", 0);
        for (int i = 0; i < buttons.Length; i++)
        {
            if (PlayerPrefs.GetInt("AnagramMaxLevel", 0) >= i)
            {
                buttons[i].transform.Find("lock").GetComponent<UnityEngine.UI.Image>().enabled = false;
            }
        }
    }

    void Update()
    {
        
    }

    public void LoadLevel(int level)
    {
        if (PlayerPrefs.GetInt("AnagramMaxLevel", 0) >= level - 1) {
            audioManager.PlayButtonPress();
            UnityEngine.SceneManagement.SceneManager.LoadScene("AnagramLevel" + level);
        }
    }

    public void GoBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelTypeSelect");
        audioManager.PlayAud();
    }
}
