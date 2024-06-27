using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemiesCanvas : MonoBehaviour
{
    [SerializeField] private GameObject EnemiesKilled;
    private TextMeshProUGUI EnemiesKilled_text;
    private int enemiesKilled;

    private void Start()
    {
        EnemiesKilled_text = EnemiesKilled.GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        NewEnemyGround.onEnemyKilled += EnemyKilled;
    }
    private void OnDisable()
    {
        NewEnemyGround.onEnemyKilled -= EnemyKilled;
    }

    private void EnemyKilled()
    {
        enemiesKilled++;
        EnemiesKilled_text.text = enemiesKilled.ToString();
    }
}
