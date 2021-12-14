using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource audii;
    public AudioClip buttonPress;
    public AudioClip back;

    // Start is called before the first frame update
    void Start()
    {
        //audii.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAud()
    {

        //0 = isMute = true
        //1 = isMute = false
        if (GetMuteEffects() != 0)
        {
            audii.PlayOneShot(back);
        }
    }

    public void PlayButtonPress()
    {
        if (GetMuteEffects() != 0)
        {
            audii.PlayOneShot(buttonPress);
        }
    }

    public void SetMuteEffects(int mut)
    {
        PlayerPrefs.SetInt("EffectsIsMuted", mut);
    }

    public int GetMuteEffects()
    {
        return PlayerPrefs.GetInt("EffectsIsMuted", 2);
    }

    public void SetMuteMusic(int mut)
    {
        PlayerPrefs.SetInt("MusicIsMuted", mut);
    }

    public int GetMuteMusic()
    {
        return PlayerPrefs.GetInt("MusicIsMuted", 2);
    }
}
