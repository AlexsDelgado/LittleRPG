using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewObstacle : MonoBehaviour, IPickupeable
{
    [SerializeField] private GameObject[] obstaculos;
    private bool inBuyRange;
    [SerializeField] private int price;
    [SerializeField] private AudioClip groundSound;
    
    
    [SerializeField] private GameObject PriceUI;
    [SerializeField] private GameObject BuyUI;
    [SerializeField] private GameObject ExpensiveUI;
    
    
    private GameObject player;
    
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
       
        openNextLevel();
        //AudioSource.PlayClipAtPoint(groundSound, transform.position);
        AudioManager.Instance.PlaySound(groundSound);
        Destroy(gameObject);
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.layer == 3)
    //     {
    //         player = collision.gameObject;
    //         inBuyRange = true;
    //     }
    // }
    //
    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     if (collision.gameObject.layer == 3)
    //     {
    //         inBuyRange = false;
    //     }
    // }
    //
    
    
    
    
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
    
    
    
    
    
    
    
    private void openNextLevel()
    {
        for (int i = 0; i < obstaculos.Length; i++)
        {
            obstaculos[i].SetActive(false);
        }
        gameObject.SetActive(false);
       
    }

}
