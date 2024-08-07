using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;
    private int coins;
    
    private void OnEnable()
    {
        NewEventHandler.Instance.onPickupCoin += UpdateCoinsUp;
        NewEventHandler.Instance.onBuyItem += UpdateCoinsDown;
        NewEventHandler.Instance.onResetGame += ResetCoins;
    }

    private void OnDisable()
    {
        NewEventHandler.Instance.onPickupCoin -= UpdateCoinsUp;
        NewEventHandler.Instance.onBuyItem -= UpdateCoinsDown;
        NewEventHandler.Instance.onResetGame -= ResetCoins;
    }
    
    private void UpdateCoinsUp(int amount)
    {
        coins += amount;
        coinsText.text = coins.ToString();
    }

    private void ResetCoins()
    {
        coins = 0;
        coinsText.text = coins.ToString();
    }
    private void UpdateCoinsDown(int amount)
    {
        coins -= amount;
        coinsText.text = coins.ToString();
    }
    
    
}
