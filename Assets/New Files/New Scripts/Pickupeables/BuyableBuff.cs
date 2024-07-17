using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyableBuff : MonoBehaviour, IPickupeable
{

    [SerializeField] private BuffPot buff;
    
    [SerializeField] private bool inBuyRange;
    
    private int price;
    
    private int STRBuff;
    private int DEFBuff;
    private int SPDBuff;
    private float attackSpeedBuff;

    private AudioClip potionSound;

    [SerializeField] private GameObject priceUI;
    [SerializeField] private GameObject buyUI;
    [SerializeField] private GameObject expensiveUI;
    
    private GameObject player;

    private void Start()
    {
        LoadStats();
    }

    public void LoadStats()
    {
        price = buff.Price;
        STRBuff = buff.STRBuff;
        DEFBuff = buff.DEFBuff;
        SPDBuff = buff.SPDBuff;
        attackSpeedBuff = buff.AttackSpeedBuff;
        GetComponent<SpriteRenderer>().sprite = buff.Sprite;
        potionSound = buff.PotionSound;
    }
    
    //public static event Action<int> onBuyItem;
    
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
        NewEventHandler.Instance.ItemBought(price);
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
            priceUI.SetActive(true);
            if (NewGameManager.Instance.Coins < price)
            {
                expensiveUI.SetActive(true);
            }
            else
            {
                buyUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            inBuyRange = false;
            priceUI.SetActive(false);
            expensiveUI.SetActive(false);
            buyUI.SetActive(false);
        }
    }
}
