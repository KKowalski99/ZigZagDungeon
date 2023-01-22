using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ZigZagDungeon
{
    public class SoundManager : MonoBehaviour
    {
        public Sound[] sounds;
        public static SoundManager Instance;
        void Awake()
        {
            if (!Instance) Instance = this; else Destroy(this);

            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;

                if (s.pitch == 0)
                {
                    s.pitch = 1;
                }
            }
        }

        public void Play(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s.loop != true)
            {
                s.source.Play();
            }
            else PlayAsLoop(s);
        }

        private void PlayAsLoop(Sound s)
        {
            if (s.source.isPlaying) return;
            else
            {
                s.source.loop = true;
                s.source.Play();
            }
        }
    }
}