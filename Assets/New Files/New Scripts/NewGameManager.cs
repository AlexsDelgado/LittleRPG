using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameManager : MonoBehaviour
{
    public static NewGameManager Instance;
    private int coins;

    
    
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
    }

    private void OnDisable()
    {
        NewCoin.onPickupCoin -= addCoins;
    }

    private void addCoins(int value)
    {
        coins += value;
        Debug.Log("coin picked up");
    }
}
