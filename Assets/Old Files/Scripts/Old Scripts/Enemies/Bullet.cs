using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    private float speed;

    public GameObject player;
    private Rigidbody2D rb;
    [SerializeField]private AudioClip clip;
    private int damage;



    
    

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        AudioManager.Instance.PlaySound(clip);
        
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;

        Destroy(this.gameObject, 2);

    }
    public void SetDamage(int dmg)
    {
        damage = dmg;
    }
    public void SetSpeed(float spd)
    {
        speed = spd;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        NewHero player = collision.gameObject.GetComponent<NewHero>();
        if (player)
        {
            player.Hurt(damage);
        }
           

    }

}
