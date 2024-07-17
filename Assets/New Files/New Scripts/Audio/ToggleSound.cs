using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSound : MonoBehaviour
{
    [SerializeField] private bool toggleMusic;
    [SerializeField] private bool toggleEffects;
    private Toggle check;
    
    public void Toggle()
    {
        if (toggleEffects) AudioManager.Instance.ToggleSfx();
        if (toggleMusic) AudioManager.Instance.ToggleBgm();

    }


}