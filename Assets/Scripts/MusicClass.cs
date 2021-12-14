﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicClass : MonoBehaviour
{
    private AudioSource _audioSource;
    private GameObject[] other;
    private bool NotFirst = false;
    private void Awake()
    {
        other = GameObject.FindGameObjectsWithTag("Music");

        foreach (GameObject oneOther in other)
        {
            if (oneOther.scene.buildIndex == -1)
            {
                NotFirst = true;
            }
        }

        if (NotFirst == true)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (GameObject.FindGameObjectWithTag("Effects").GetComponent<AudioManager>().GetMuteMusic() != 0) {
            if (_audioSource.isPlaying) return;
            _audioSource.Play();
        }
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
