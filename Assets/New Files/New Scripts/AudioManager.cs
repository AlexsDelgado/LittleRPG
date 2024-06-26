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
    
    
    
    public void PlaySound(AudioClip p_clip)
    {
        audioSource.PlayOneShot(p_clip);
    }

    public void PlayMusic()
    {
        musicSource.Play();
    }
}
