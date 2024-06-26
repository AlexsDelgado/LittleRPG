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
    
    public static NewGameManager Instance;
    private int coins;
    private ICoinsCanvasProvider _coinsCanvasProvider;
    public UnityEvent menu = new UnityEvent();
    public UnityEvent lose = new UnityEvent();
    public UnityEvent win = new UnityEvent();
    public UnityEvent cave = new UnityEvent();

    private void Start()
    {
        _coinsCanvasProvider = MainCanvas.Instance;
        _coinsCanvasProvider.CoinsCanvas.UpdateCoins(coins);
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
        NewCoin.onPickupCoin += addCoins;
        BuyableBuff.onBuyItem += subtractCoins;
        NewObstacle.onBuyItem += subtractCoins;
    }

    private void OnDisable()
    {
        NewCoin.onPickupCoin -= addCoins;
        BuyableBuff.onBuyItem -= subtractCoins;
        NewObstacle.onBuyItem -= subtractCoins;
    }

    private void addCoins(int value)
    {
        coins += value;
        _coinsCanvasProvider.CoinsCanvas.UpdateCoins(coins);
    }

    private void subtractCoins(int value)
    {
        coins -= value;
        _coinsCanvasProvider.CoinsCanvas.UpdateCoins(coins);
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
}
