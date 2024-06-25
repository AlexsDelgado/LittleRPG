using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public float speed;
    public float chaseDist;
    public float stopDist;
    private float timer;
    private float timerLimit;

    public GameObject target;
    public GameObject bullet;
    public GameObject firePoint;
    private Animator anim;
    public HUD hudReference;

    private float targetDist;


    private void Start()
    {
        GameManager.Instance.bossDMG.AddListener(getDamage);
        timerLimit = 2;
        health = maxHealth;
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        timer += Time.deltaTime;

        targetDist = Vector2.Distance(transform.position, target.transform.position);

        if (targetDist < chaseDist && targetDist > stopDist)
        {
            ChasePlayer();
        }
        else if (timer > timerLimit)
        {
            timer = 0;
            Shoot();
        }
        if (health <  maxHealth/ 4)
        {
            timerLimit = 0.5f;
        }
        if(health <= 3)
        {
            timerLimit = 0.2f;
        }
    }
    public void getDamage()
    {
        health--;

        anim.SetTrigger("TakeHit");
        anim.SetBool("Move", false);

        if (health <= 0)
        {
            Destroy(this);
            GameManager.Instance.win.Invoke();
        }
    }
    private void ChasePlayer()
    {
        if (transform.position.x < target.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(5,5, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-5, 5, 1);
        }

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        anim.SetBool("Move", true);
    }

    private void Shoot()
    {
        Instantiate(bullet, firePoint.transform.position, Quaternion.identity);

        anim.SetTrigger("Attack");
        anim.SetBool("Move", false);
    }


}
