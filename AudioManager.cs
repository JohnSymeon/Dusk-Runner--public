/*
Used to control the game's audio.
*/
using UnityEngine.Audio;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }
   void Start()
   {
        Play("Theme");
   }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds,sound=>sound.name==name);
        s.source.Play(); 
    }

    public void StopPlaying(string name)
    {
        Sound s = Array.Find(sounds,sound=>sound.name==name);
        s.source.volume =0f;
        s.source.Stop();
    }
