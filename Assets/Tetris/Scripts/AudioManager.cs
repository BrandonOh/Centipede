using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public TetrisSounds[] sounds; 

    // Start is called before the first frame update
    void Awake()
    {
        foreach (TetrisSounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        TetrisSounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    } 
}
