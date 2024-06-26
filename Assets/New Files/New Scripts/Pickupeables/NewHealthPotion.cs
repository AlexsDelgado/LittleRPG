using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHealthPotion : MonoBehaviour, IPickupeable
{
    [SerializeField] private int healAmount;
    [SerializeField] private AudioClip potionAudio;
    private GameObject player;
    
    public void OnPickup()
    {
        player.GetComponent<NewHero>().Heal(healAmount);
        AudioSource.PlayClipAtPoint(potionAudio, transform.position);
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
