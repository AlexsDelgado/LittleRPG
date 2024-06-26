using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class NewCoin : MonoBehaviour, IPickupeable
{
    [SerializeField] private int value;
    [SerializeField] private AudioClip pickupSound;
    
    public static event Action<int> onPickupCoin;

    public void OnPickup()
    {
        onPickupCoin?.Invoke(value);
        AudioSource.PlayClipAtPoint(pickupSound, transform.position);
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
