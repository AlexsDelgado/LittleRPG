using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource, musicSource;
    public static AudioManager Instance;
    [SerializeField] private AudioClip environment, bossFight;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);                                                       
        }
        else
        {
            Destroy(this);
        }
        
        PlayMusic();
    }


    public void StopMusic()
    {
        musicSource.Stop();
    }
    public void PlaySound(AudioClip p_clip)
    {
        audioSource.PlayOneShot(p_clip);
    }

    public void PlayMusic()
    {
        musicSource.clip = environment;
        musicSource.Play();
    }

    public void PlayMusicBoss()
    {
        musicSource.clip = bossFight;
        musicSource.Play(); 
    }
    
    
    private void Start()
    {
        AudioListener.volume = 0.2f;
    }

    public void ToggleSfx()
    {
        audioSource.mute = !audioSource.mute;
    }
    public void ToggleBgm()
    {
        musicSource.mute = !musicSource.mute;
    }
    
    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }
    
}
