using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public UnityEvent OnCoinGrab = new UnityEvent();
    public  AudioSource moneda;
    private void Start()
    {
       GameManager.Instance.AddCoin(this);
       moneda = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Hero player = collision.gameObject.GetComponent<Hero>();
            if (player)
            {
                OnCoinGrab.Invoke();
           
               //msoneda.Play();
                gameObject.SetActive(false);
            }
        }   
    }
}
