using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Potion : MonoBehaviour
{

    [SerializeField] private AudioClip m_potionAudio;
    public HUD UI;
    public int Price;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Hero player = collision.gameObject.GetComponent<Hero>();
            if (player)
            {
                if (GameManager.Instance.m_coins>=Price)
                {
                    UI.heal();
                    //sounds.Instance.PlayOneShot(m_potionAudio);
                    GameManager.Instance.AddHealth();
                    
                    //GameManager.Instance.m_coins -= Price;
                    UI.buyItem();
                    GameManager.Instance.buyItem(Price); 
                    gameObject.SetActive(false);
                }
                else
                {
                    Debug.Log("no hay monedas suficientes");
                }
               
            }
        }
    }
}
