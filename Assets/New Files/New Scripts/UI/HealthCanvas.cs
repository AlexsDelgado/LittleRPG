using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        
        for (int i = 0; i < newHealth; i++)
        {
            Hearts[i].sprite = heart;
        }

        for (int i = newHealth; i < maxHealth; i++)
        {
            Hearts[i].sprite = damagedHeart;
        }
    }
}
