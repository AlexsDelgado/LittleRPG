using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource, musicSource;
    public static AudioManager Instance;
    
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
    
    
    pu
    public void PlaySound(AudioClip p_clip)
    {
        audioSource.PlayOneShot(p_clip);
    }

    public void PlayMusic()
    {
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
