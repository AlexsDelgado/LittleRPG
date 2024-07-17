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

    [SerializeField] private GameObject PriceUI;
    [SerializeField] private GameObject BuyUI;
    [SerializeField] private GameObject ExpensiveUI;

    
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
        AudioManager.Instance.PlaySound(potionSound);
        //AudioSource.PlayClipAtPoint(potionSound, transform.position);
        Destroy(gameObject);
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            player = collision.gameObject;
            inBuyRange = true;
            PriceUI.SetActive(true);
            if (NewGameManager.Instance.Coins < price)
            {
                ExpensiveUI.SetActive(true);
            }
            else
            {
                BuyUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            inBuyRange = false;
            PriceUI.SetActive(false);
            ExpensiveUI.SetActive(false);
            BuyUI.SetActive(false);
        }
    }
}
