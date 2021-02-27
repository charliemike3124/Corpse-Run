﻿using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sounds
{
    public AudioClip clip;

    public string name;

    [Range(0,1)]
    public float volume;

    [Range(0,3)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

    
}
