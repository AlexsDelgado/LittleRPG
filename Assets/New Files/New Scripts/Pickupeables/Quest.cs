using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour, IPickupeable
{
    public static event Action onPickupQuest;
    
    public void OnPickup()
    {
        onPickupQuest?.Invoke();
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            OnPickup();
        }
    }
}
