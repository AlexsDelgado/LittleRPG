using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public float speed;

    public GameObject player;
    private Rigidbody2D rb;



    
    

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;

        Destroy(this.gameObject, 2);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hero player = collision.gameObject.GetComponent<Hero>();
        if (player)
        {
            GameManager.Instance.getDamage();
        }
           

    }

}
