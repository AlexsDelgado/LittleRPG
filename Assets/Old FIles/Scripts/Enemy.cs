using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] float patrolTime = 2.0f;
    [SerializeField] float initialSpeed = 5.0f;
    Vector3 direction = new Vector3(1, 0, 0);
    


    bool right = true;
    float currentTime;
    public GameObject target;


    public float chaseDist;
    public float stopDist;
    private float targetDist;



    public UnityEvent hitPlayer = new UnityEvent();


    void Start()
    {
        GameManager.Instance.AddEnemy(this);
        GameManager.Instance.agregarEnemigo.Invoke();
        
    }


    void Update()
    {


        targetDist = Vector2.Distance(transform.position, target.transform.position);

        if (targetDist < chaseDist && targetDist > stopDist)
        {
            ChasePlayer();
        }
        else
        {
            patrol();
        }

  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.layer == 3)
        {
            Hero player = collision.gameObject.GetComponent<Hero>();
            if (player)
            {
                Rigidbody2D rb2DCol = player.gameObject.GetComponent<Rigidbody2D>();
                hitPlayer.Invoke();
                Vector3 dir = (player.transform.position - transform.position).normalized;
                rb2DCol.AddForce(dir * 100f, ForceMode2D.Impulse);
                gameObject.GetComponent<Rigidbody2D>().AddForce(dir * 2f *-1, ForceMode2D.Impulse);
            }      
        }
    }


    public void patrol()
    {
        currentTime += Time.deltaTime;
        if (currentTime > patrolTime)
        {
            if (right)
            {
                right = false;
            }
            else
            {
                right = true;
            }
            currentTime = 0;
        }
        if (right)
        {
            transform.position += new Vector3(1,0,0) * initialSpeed * Time.deltaTime;
            gameObject.transform.localScale = new Vector3(5, 5, 1);

        }
        else
        {
            transform.position += new Vector3(-1, 0, 0) * initialSpeed * Time.deltaTime;
            gameObject.transform.localScale = new Vector3(-5, 5, 1);

        }
    }

    private void ChasePlayer()
    {
        if (transform.position.x < target.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(5, 5, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-5, 5, 1);
        }

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, initialSpeed * Time.deltaTime);
    }

}
