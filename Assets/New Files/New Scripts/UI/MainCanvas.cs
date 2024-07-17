using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour, IHealthCanvasProvider, IStatsCanvasProvider, IEnemiesCanvasProvider, ICoinsCanvasProvider
{
    [SerializeField] private HealthCanvas _healthCanvas;
    [SerializeField] private EnemiesCanvas _enemiesCanvas;
    [SerializeField] private StatsCanvas _statsCanvas;
    [SerializeField] private CoinsCanvas _coinsCanvas;

    public HealthCanvas HealthCanvas => _healthCanvas;
    public StatsCanvas StatsCanvas => _statsCanvas;
    public EnemiesCanvas EnemiesCanvas => _enemiesCanvas;
    public CoinsCanvas CoinsCanvas => _coinsCanvas;
    
    public static MainCanvas Instance { get; private set; }

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
    }
}
