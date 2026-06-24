using UnityEngine;
using System.Collections.Generic;

namespace Hack4Fun.Utils
{
    /// <summary>
    /// Manages all audio in the game - music and sound effects
    /// </summary>
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        private AudioSource musicSource;
        private AudioSource sfxSource;
        private Dictionary<string, AudioClip> soundEffects = new Dictionary<string, AudioClip>();

        [SerializeField] private float masterVolume = 1f;
        [SerializeField] private float musicVolume = 0.7f;
        [SerializeField] private float sfxVolume = 0.8f;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Create audio sources
            musicSource = gameObject.AddComponent<AudioSource>();
            sfxSource = gameObject.AddComponent<AudioSource>();

            musicSource.volume = musicVolume * masterVolume;
            sfxSource.volume = sfxVolume * masterVolume;
        }

        /// <summary>
        /// Play a sound effect
        /// </summary>
        public void PlaySFX(string sfxName)
        {
            if (soundEffects.ContainsKey(sfxName))
            {
                sfxSource.PlayOneShot(soundEffects[sfxName]);
            }
            else
            {
                Debug.LogWarning($"[AudioManager] Sound effect '{sfxName}' not found");
            }
        }

        /// <summary>
        /// Play music
        /// </summary>
        public void PlayMusic(AudioClip clip, bool loop = true)
        {
            if (musicSource.clip == clip && musicSource.isPlaying)
                return;

            musicSource.clip = clip;
            musicSource.loop = loop;
            musicSource.Play();
        }

        /// <summary>
        /// Stop music
        /// </summary>
        public void StopMusic()
        {
            musicSource.Stop();
        }

        /// <summary>
        /// Set master volume
        /// </summary>
        public void SetMasterVolume(float volume)
        {
            masterVolume = Mathf.Clamp01(volume);
            UpdateVolumes();
        }

        /// <summary>
        /// Set music volume
        /// </summary>
        public void SetMusicVolume(float volume)
        {
            musicVolume = Mathf.Clamp01(volume);
            UpdateVolumes();
        }

        /// <summary>
        /// Set SFX volume
        /// </summary>
        public void SetSFXVolume(float volume)
        {
            sfxVolume = Mathf.Clamp01(volume);
            UpdateVolumes();
        }

        private void UpdateVolumes()
        {
            musicSource.volume = musicVolume * masterVolume;
            sfxSource.volume = sfxVolume * masterVolume;
        }

        /// <summary>
        /// Register a sound effect
        /// </summary>
        public void RegisterSFX(string name, AudioClip clip)
        {
            if (!soundEffects.ContainsKey(name))
            {
                soundEffects.Add(name, clip);
            }
        }
    }
}
