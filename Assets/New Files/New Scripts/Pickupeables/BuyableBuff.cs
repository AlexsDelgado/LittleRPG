using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyableBuff : MonoBehaviour, IPickupeable
{
    private bool inBuyRange;
    
    [SerializeField] private int price;
    
    [SerializeField] private int STRBuff;
    [SerializeField] private int DEFBuff;
    [SerializeField] private int SPDBuff;
    [SerializeField] private float attackSpeedBuff;

    [SerializeField] private AudioClip potionSound;
    
    private GameObject player;
    
    
    public static event Action<int> onBuyItem;
    
    void Update()
    {
        if (inBuyRange)
        {
            if (Input.GetKeyDown(KeyCode.E) && NewGameManager.Instance.Coins >= price)
            {
                OnPickup();
            }
        }
    }
    
    public void OnPickup()
    {
        onBuyItem?.Invoke(price);
        player.GetComponent<NewHero>().Buff(STRBuff, DEFBuff, SPDBuff, attackSpeedBuff);
        AudioSource.PlayClipAtPoint(potionSound, transform.position);
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            player = collision.gameObject;
            inBuyRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            inBuyRange = false;
        }
    }
}
