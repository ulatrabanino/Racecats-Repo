using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //keeps track of sounds
    public Sound[] sounds;

    void Awake()
    {
        //assign attributes for each sound clip in array
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch= s.pitch;
            s.source.loop = s.loop;
        }
    }

    //play sound clip
    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null) {
            s.source.Play();
        }
    }

    //stop sound clip
    public void Stop(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null) {
            s.source.Stop();
        }
    }
}
