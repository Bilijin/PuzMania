using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnagramLevel : MonoBehaviour
{
    public string word;
    public UnityEngine.UI.Text[] anagrams;
    public int level;
    public GameObject gameWinUi;
    public GameObject popUp;

    private string wordInProgress;
    private int found = 0;
    //private PopUp pop = new PopUp();
    private int count = 101;
    private AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Effects").GetComponent<AudioManager>();
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().StopMusic();
    }

    void Update()
    {
        if (count < 100)
        {
            count++;
        }

        if (count == 100)
        {
            HidePopUp();
        }
    }

    public void ClickButton(string letter)
    {
        audioManager.PlayButtonPress();
        wordInProgress += letter;

        if(wordInProgress.Length == word.Length)
        {
            CheckWord(wordInProgress);
            wordInProgress = "";
        }
    }

    void CheckWord(string wor)
    {
        for (int i = 0; i < anagrams.Length; i++)
        {
            if (wor.ToLower() == anagrams[i].text.ToLower())
            {
                anagrams[i].color = Color.black;
                found++;
                break;
            }
            else if(i == anagrams.Length - 1)
            {
                ShowPopUp("That isn't a valid anagram. Try again!");
            }
        }

        if(found == anagrams.Length)
        {
            if (PlayerPrefs.GetInt("AnagramMaxLevel", 0) < level)
            {
                PlayerPrefs.SetInt("AnagramMaxLevel", level);
            }
            gameWinUi.SetActive(true);
        }
    }

    public void GoBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("AnagramSelect");
        audioManager.PlayAud();
    }

    public void GoToNext()
    {
        if(level + 1 < 20)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("AnagramLevel" + (level + 1));
        }
        else
        {
            gameWinUi.gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }
    }

    void ShowPopUp(string text)
    {
        popUp.GetComponentInChildren<UnityEngine.UI.Text>().text = text;

        popUp.SetActive(true);
        count = 0;
    }

    void HidePopUp()
    {
        popUp.SetActive(false);
        count = 101;
    }
}
