using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBossEnemy : Unit
{

    [SerializeField] private  UnitStat UNIT;
    private bool right = true; 
    [SerializeField] private GameObject target; 
    private float SPD;
    private float bulletSPD;
    
    [SerializeField] private float chaseDist;
    [SerializeField] private float stopDist;
    private bool chase = false;
    private float targetDist;
    private Unit typeEnemy;
    private float timer;
    private float timerLimit;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject firePoint;
    
    
    private void LoadStats()
    {
        MaxHP = UNIT.MaxHP;
        HP = UNIT.HP;
        STR = UNIT.STR;
        DEF = UNIT.DEF;
        SPD = UNIT.SPD;
        bulletSPD = 5;
    }

    public float GetSPD()
    {
        return SPD;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        timerLimit = 2;
        LoadStats();
    }

    private void Update()
    {
            // transform.position = Vector2.MoveTowards(transform.position,target.transform.position,Time.deltaTime*SPD);
            // targetDist = Vector2.Distance(transform.position, target.transform.position);
            
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
            if (HP <=  MaxHP/2)
            {
                timerLimit = 0.7f;
                bulletSPD = 8;
            }
            if(HP <= MaxHP/5)
            {
                timerLimit = 0.2f;
                bulletSPD = 10;
            }
    }
    
    
    private void Shoot()
    {
        
        GameObject auxBullet = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
        auxBullet.GetComponent<Bullet>().SetDamage(STR);
        auxBullet.GetComponent<Bullet>().SetSpeed(bulletSPD);

        animator.SetTrigger("Attack");
        animator.SetBool("Move", false);
    }

    private void ChasePlayer()
    {
        if (transform.position.x < target.transform.position.x && !right)
        {
          
            //gameObject.transform.localScale = new Vector3(5,5, 1);
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
            right = true;
        }
        else if (transform.position.x > target.transform.position.x && right)
        {

            gameObject.transform.Rotate(new Vector3(0, 180, 0));
            right = false;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, SPD * Time.deltaTime);

        animator.SetBool("Move", true);
    }
    
    
    //
    // public void SetTarget(GameObject newTarget)
    // {
    //     target = newTarget;
    // }

    public override void Hurt(int dmg)
    {
        animator.SetTrigger("TakeHit");
        animator.SetBool("Move", false);
        int dmgFinal = calculateDamage(dmg);
        HP = HP - dmgFinal;
        if (HP <= 0)
        {
            SceneManager.LoadScene("NewWin");
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        typeEnemy = collision.gameObject.GetComponent<NewHero>();
        if (typeEnemy is NewHero)
        {
            Debug.Log("is enemy");
            
            typeEnemy.Hurt(STR);
        }
    }
}
