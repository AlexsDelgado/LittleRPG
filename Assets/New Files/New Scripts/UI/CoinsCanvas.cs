using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;


    public void UpdateCoins(int amount)
    {
        coinsText.text = amount.ToString();
    }
    
    
}
