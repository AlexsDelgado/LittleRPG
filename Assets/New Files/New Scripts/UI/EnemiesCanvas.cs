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
        NewEventHandler.Instance.onResetGame+= ResetEnemies;
    }
    
    private void OnDisable()
    {
        NewEventHandler.Instance.onEnemyKilled -= EnemyKilled;
        NewEventHandler.Instance.onResetGame-= ResetEnemies;
    }

    private void ResetEnemies()
    {
        enemiesKilled = 0;
        EnemiesKilled_text.text = enemiesKilled.ToString();
    }
    private void EnemyKilled()
    {
        enemiesKilled++;
        EnemiesKilled_text.text = enemiesKilled.ToString();
    }
}
