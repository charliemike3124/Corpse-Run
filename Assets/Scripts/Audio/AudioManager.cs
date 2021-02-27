using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;
    public static AudioManager Instance;

    private void Awake()
    {
        Instance = Instance == null ? this : null;

        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.enabled = true;
        }
    }

    void Start()
    {
        play("Main Music");
    }
    public void play(string name)
    {
        Sounds s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null)
        {
            Debug.Log("Sound with this name isnt found.");
            return;
        }
        s.source.Play();
    }

    public void setVolumeAndPitch(string name, float volume, float pitch)
    {
        Sounds s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null)
        {
            Debug.Log("Sound with this name isnt found.");
            return;
        }
        s.source.volume = volume;
        s.source.pitch = pitch;
    }


    
}
