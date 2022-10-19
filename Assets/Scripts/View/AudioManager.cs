using System;
using Model;
using UnityEngine;

namespace View
{
    public class AudioManager : MonoBehaviour
    {
        public Sound[] sounds;

        public static AudioManager audioManager;
        private void Awake()
        {
            if (audioManager != null && audioManager != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                audioManager = this; 
                DontDestroyOnLoad(gameObject);
            }
            foreach (Sound sound in sounds)
            {
                sound.audioSource = gameObject.AddComponent<AudioSource>();
                sound.audioSource.clip = sound.audioClip;
                sound.audioSource.volume = sound.volume;
                sound.audioSource.pitch = sound.pitch;
                sound.audioSource.loop = sound.isLoop;
            }
        }

        private void Start()
        {
            PlayMusic("MainTheme");
        }

        public void PlayMusic(string name)
        {
            Sound sound = Array.Find(sounds, sound => sound.name == name);
            sound.audioSource.Play();
        }

        public static void PlayButtonEffect()
        {
            FindObjectOfType<AudioManager>().PlayMusic("Button");
        }

        public static void PlayNormalColide()
        {
            FindObjectOfType<AudioManager>().PlayMusic("Colide");
        }
    }
}