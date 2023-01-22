using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ZigZagDungeon
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        [HideInInspector] public AudioSource source;

        [Range(0f, 1f)] public float volume;
        [Range(0.1f, 3f)] public float pitch;
        [Range(0f, 1f)] public float spatialBlend;
        public bool loop;
    }
}