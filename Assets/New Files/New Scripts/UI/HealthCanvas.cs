using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class HealthCanvas : MonoBehaviour
{
    [SerializeField] private Image[] Hearts;

    [SerializeField] private Sprite heart;
    [SerializeField] private Sprite damagedHeart;

    public void UpdateHealth(int newHealth, int maxHealth)
    {
        
        for (int i = 0; i < maxHealth; i++)
        {
            Hearts[i].enabled = true;
        }
        
        for (int i = 0; i < Math.Clamp(newHealth, 0, maxHealth); i++)
        {
            Hearts[i].sprite = heart;
        }

        for (int i = Math.Clamp(newHealth, 0, maxHealth); i < maxHealth; i++)
        {
            Hearts[i].sprite = damagedHeart;
        }
    }
    
    private void OnEnable()
    {
        NewEventHandler.Instance.onResetGame += ResetHealth;
    }

    private void OnDisable()
    {
        NewEventHandler.Instance.onResetGame -= ResetHealth;
    }

    private void ResetHealth()
    {
        for (int i = 0; i < 6; i++)
        {
            Hearts[i].sprite = heart;
        }
    }
}
