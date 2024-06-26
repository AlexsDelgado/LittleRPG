using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewGameManager : MonoBehaviour
{
    
    public static NewGameManager Instance;
    private int coins;
    private ICoinsCanvasProvider _coinsCanvasProvider;

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
    }

    private void OnDisable()
    {
        NewCoin.onPickupCoin -= addCoins;
        BuyableBuff.onBuyItem -= subtractCoins;
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
}
