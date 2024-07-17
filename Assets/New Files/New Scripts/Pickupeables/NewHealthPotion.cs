using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHealthPotion : MonoBehaviour, IPickupeable
{
    [SerializeField] private HPPot Hp;
    
    private int healAmount;
    private AudioClip potionSound;
    private GameObject player;
    
    
    private void Start()
    {
        LoadStats();
    }
    
    public void LoadStats()
    {
        healAmount = Hp.HealAmount;
        potionSound = Hp.PotionSound;
        GetComponent<SpriteRenderer>().sprite = Hp.Sprite;
    }
    
    public void OnPickup()
    {
        player.GetComponent<NewHero>().Heal(healAmount);
        AudioManager.Instance.PlaySound(potionSound);
        //AudioSource.PlayClipAtPoint(potionSound, transform.position);
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            player = collision.gameObject;
            OnPickup();
        }
    }
    
}
