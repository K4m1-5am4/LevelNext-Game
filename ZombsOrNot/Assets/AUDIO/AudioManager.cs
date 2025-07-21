using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)] public float volume = 1f;
        [Range(0.1f, 3f)] public float pitch = 1f;
        public bool loop = false;
        [HideInInspector] public AudioSource source;
    }

    public List<Sound> sounds = new List<Sound>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    public void Play(string soundName)
    {
        Sound sound = sounds.Find(s => s.name == soundName);
        if (sound != null)
        {
            sound.source.Play();
        }
        else
        {
            Debug.LogWarning("Sound not found: " + soundName);
        }
    }
    public void Stop(string soundName)
    {
        Sound sound = sounds.Find(s => s.name == soundName);
        if (sound != null) sound.source.Stop();
    }

    public void SetVolume(string soundName, float volume)
    {
        Sound sound = sounds.Find(s => s.name == soundName);
        if (sound != null) sound.source.volume = volume;
    }
}