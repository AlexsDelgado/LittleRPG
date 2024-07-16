using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemiesCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI EnemiesKilled_text;
    private int enemiesKilled;
    
    private void OnEnable()
    {
        NewEventHandler.Instance.onEnemyKilled += EnemyKilled;
    }
    
    private void OnDisable()
    {
        NewEventHandler.Instance.onEnemyKilled -= EnemyKilled;
    }

    private void EnemyKilled()
    {
        enemiesKilled++;
        EnemiesKilled_text.text = enemiesKilled.ToString();
    }
}
