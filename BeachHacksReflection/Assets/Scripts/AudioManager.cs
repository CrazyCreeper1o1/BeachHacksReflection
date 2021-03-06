﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 0.7f;
    [Range(0f, 2f)]
    public float pitch = 1f;
    [Range(0f, 0.5f)]
    public float randomVolume = 0.1f;
    [Range(0f, 0.5f)]
    public float randomPitch = 0.1f;
    public bool isLooped;
    


    private AudioSource source;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }

    public void Play()
    {
        source.volume = volume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));
        source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f)); ;
        source.loop = isLooped;
        source.Play();
    }
    public void Stop()
    {
        source.Stop();
    }

    public void PlayScheduled(double time)
    {
        source.volume = volume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));
        source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f)); ;
        source.loop = isLooped;
        while (time < 0)
            time += 120;
        source.time = (int) (time % 120);
        source.Play();
        Debug.Log(source.time);
        //source.PlayScheduled(AudioSettings.dspTime - time);
        //Debug.Log("It's playing here at " + (time));
    }
}

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;


    [SerializeField]
    Sound[] sounds;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one AudioManager in the scene.");
        }
        else
            instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());

        }
        PlaySound("Ambient");
    }

    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }

        Debug.LogWarning("AudioManager: Sound not found in list: " + _name);
    }

    public void StopSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Stop();
                return;
            }
        }

        Debug.LogWarning("AudioManager: Sound not found in list: " + _name);
    }

    public void PlaySound(string _name, double startTime)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].PlayScheduled(startTime);
                return;
            }
        }

        Debug.LogWarning("AudioManager: Sound not found in list: " + _name);
    }
}
