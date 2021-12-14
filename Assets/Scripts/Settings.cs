using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public UnityEngine.UI.Toggle soundToggle;
    public UnityEngine.UI.Toggle musicToggle;

    private AudioManager audioManager;
    private MusicClass musicClass;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Effects").GetComponent<AudioManager>();
        musicClass = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>();

        switch (audioManager.GetMuteEffects()){
            case 0: 
                soundToggle.isOn = false;
                break;
            case 1:
                soundToggle.isOn = true;
                break;
        }

        switch (audioManager.GetMuteMusic())
        {
            case 0:
                musicToggle.isOn = false;
                break;
            case 1:
                musicToggle.isOn = true;
                break;
        }

        musicClass.PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnOffSoundEffects(bool isOn)
    {
        audioManager.PlayButtonPress();
        if (isOn)
        {
            audioManager.SetMuteEffects(1);
        }
        else
        {
            audioManager.SetMuteEffects(0);
        }
    }

    public void OnOffSoundMusic(bool isOn)
    {
        audioManager.PlayButtonPress();
        if (isOn)
        {
            audioManager.SetMuteMusic(1);
            musicClass.PlayMusic();
        }
        else
        {
            audioManager.SetMuteMusic(0);
            musicClass.StopMusic();
        }
    }

    public void GoBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        audioManager.PlayAud();
    }
}
