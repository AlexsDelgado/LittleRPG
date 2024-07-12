using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEventHandler : MonoBehaviour
{
    public static NewEventHandler Instance;
    
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
    
    public event Action<int> onBuyItem;
    public event Action<int> onPickupCoin;
    public event Action onPickupQuest;
    public event Action onEnemyKilled;

    public void ItemBought(int price)
    {
        onBuyItem?.Invoke(price);
    }
    
    public void CoinPickedUp(int value)
    {
        onPickupCoin?.Invoke(value);
    }
    
    public void QuestPickedUp()
    {
        onPickupQuest?.Invoke();
    }

    public void EnemyKilled()
    {
        onEnemyKilled?.Invoke();
    }
}
