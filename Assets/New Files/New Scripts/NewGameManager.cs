using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class NewGameManager : MonoBehaviour
{
    [SerializeField] bool questAccepted;
    [SerializeField] bool questCompleted;
    public static NewGameManager Instance;
    private int coins;
    private ICoinsCanvasProvider _coinsCanvasProvider;
    //public UnityEvent menu = new UnityEvent();
    //public UnityEvent lose = new UnityEvent();
    //public UnityEvent win = new UnityEvent();
    public UnityEvent cave = new UnityEvent();
    //public UnityEvent nextLevel = new UnityEvent();

    private int killedEnemies;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        if (questAccepted && killedEnemies >= 10 &&!questCompleted)
        {
            addCoins(20);
            questCompleted = true;
        }

        //if (!MainCanvas.Instance) return;
        //_coinsCanvasProvider = MainCanvas.Instance;
    }

    public int Coins
    {
        get { return coins; }
    }
    
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

    private void OnEnable()
    {
        NewEventHandler.Instance.onPickupCoin += addCoins;
        NewEventHandler.Instance.onBuyItem += subtractCoins;
        NewEventHandler.Instance.onPickupQuest += EnableQuest;
        NewEventHandler.Instance.onEnemyKilled += EnemyKilled;
    }

    private void OnDisable()
    {
        NewEventHandler.Instance.onPickupCoin -= addCoins;
        NewEventHandler.Instance.onBuyItem -= subtractCoins;
        NewEventHandler.Instance.onPickupQuest -= EnableQuest;
        NewEventHandler.Instance.onEnemyKilled -= EnemyKilled;
    }

    private void addCoins(int value)
    {
        coins += value;
    }

    private void subtractCoins(int value)
    {
        coins -= value;
    }

    public void LoadCave()
    {
        cave.Invoke();
    }

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.O))
    //     {
    //         nextLevel.Invoke();
    //     }
    // }
    private void EnableQuest()
    {
        questAccepted = true;
    }

    public void EnemyKilled()
    {
        killedEnemies++;
    }
}
