using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleLevel : MonoBehaviour
{
    public UnityEngine.UI.Text riddleText;
    public UnityEngine.UI.InputField inputField;
    public GameObject gameWinUi;
    public GameObject popUp;
    public GameObject hintUi;

    private int level;

    private Riddles riddle = new Riddles();
    private string levelAnswer;
    private int count = 101;
    private int count2 = 201;
    private AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Effects").GetComponent<AudioManager>();
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().StopMusic();

        level = PlayerPrefs.GetInt("RiddleCurrentLevel", 1);
        levelAnswer = riddle.GetAnswer(level);
        riddleText.text = riddle.GetRiddle(level);

        hintUi.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = riddle.GetHint(level);
        hintUi.transform.GetChild(2).GetComponent<UnityEngine.UI.Text>().text = levelAnswer;
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

        if (count2 < 200)
        {
            count2++;
        }

        if (count2 == 200)
        {
            ShowOrHideHintUi();
        }
    }

    public void CheckAnswer()
    {
        audioManager.PlayButtonPress();
        if (inputField.text.ToLower() == levelAnswer.ToLower())
        {
            if (PlayerPrefs.GetInt("RiddleMaxLevel", 0) < level)
            {
                PlayerPrefs.SetInt("RiddleMaxLevel", level);
            }
            gameWinUi.SetActive(true);
        }
        else
        {
            ShowPopUp("That's not the answer to the riddle. Try again!");
        }
    }

    public void ReLoadScene()
    {
        if(level + 1 > 20)
        {
            audioManager.PlayButtonPress();
            UnityEngine.SceneManagement.SceneManager.LoadScene("RiddleSelect");
        }
        level++;
        levelAnswer = riddle.GetAnswer(level);
        riddleText.text = riddle.GetRiddle(level);
        gameWinUi.SetActive(false);
        inputField.text = "";
        hintUi.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = riddle.GetHint(level);
        hintUi.transform.GetChild(2).GetComponent<UnityEngine.UI.Text>().text = levelAnswer;
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

    public void ShowOrHideHintUi()
    {
        if (hintUi.activeInHierarchy)
        {
            hintUi.SetActive(false);
            count2 = 201;
        }
        else
        {
            hintUi.SetActive(true);
            count2 = 0;
        }
    }

    public void ShowAnswer()
    {
        hintUi.transform.GetChild(2).gameObject.SetActive(true);
    }

    public void GoBack()
    {
        PlayerPrefs.SetInt("RiddleCurrentLevel", 0);
        UnityEngine.SceneManagement.SceneManager.LoadScene("RiddleSelect");
        audioManager.PlayAud();
    }
}
