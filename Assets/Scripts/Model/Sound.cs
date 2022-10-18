using UnityEngine;
namespace Model
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        
        public AudioClip audioClip;
        
        [Range(0f,1f)]
        public float volume;
        [Range(1f,3f)]
        public float pitch;
        public bool isLoop;

        [HideInInspector]
        public AudioSource audioSource;
    }
}