using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsCanvas : MonoBehaviour
{
    [SerializeField] private GameObject coins;
    private TextMeshProUGUI coinsText;

    private void Start()
    {
        coinsText = coins.GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCoins(int amount)
    {
        coinsText.text = amount.ToString();
    }
    
    
}
