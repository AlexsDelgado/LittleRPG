using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class NewEnemyGround : Unit
{
    [SerializeField] private  UnitStat UNIT;
    [SerializeField] float patrolTime = 2.0f;
    public bool right = true;
    float currentTime;
    private GameObject target; 
    private float SPD;
    
    public float chaseDist;
    public float stopDist;
    public bool chase = false;
    private float targetDist;
    private Unit typeEnemy;
    
    //public static event Action onEnemyKilled;

    [SerializeField] private GameObject CoinDrop;
    [SerializeField] private GameObject SmallHealthDrop;
    [SerializeField] private GameObject MediumHealthDrop;
    
    public void LoadStats()
    {
        MaxHP = UNIT.MaxHP;
        HP = UNIT.HP;
        STR = UNIT.STR;
        DEF = UNIT.DEF;
        SPD = UNIT.SPD;
    }

    public float GetSPD()
    {
        return SPD;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        LoadStats();
    }

    private void Update()
    {
        if (chase == true && target!=null)
        {
            transform.position = Vector2.MoveTowards(transform.position,target.transform.position,Time.deltaTime*SPD);
            targetDist = Vector2.Distance(transform.position, target.transform.position);
            if (targetDist > stopDist)
            {
                chase =false;
            }
        }
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    public override void Hurt(int dmg)
    {
        
        int dmgFinal = calculateDamage(dmg);
        HP = HP - dmgFinal;
        if (HP <= 0)
        {
            NewEventHandler.Instance.EnemyKilled();
            //GameObject newDrop = Instantiate(CoinDrop, transform.position, transform.rotation);
            RandomDrop();
            Destroy(gameObject);
            //drop();
        }
    }

    private void RandomDrop()
    {
        int roll = Random.Range(0, 101);
        GameObject drop = null;
        if (roll > 20)
        {
            drop = CoinDrop;
        }
        if (roll > 80)
        {
            drop = SmallHealthDrop;
        }
        if (roll > 95)
        {
            drop = MediumHealthDrop;
        }
        //Debug.Log("Roll: " + roll);
        if (drop != null)
        {
            GameObject newDrop = Instantiate(drop, transform.position, transform.rotation);
            //Debug.Log("Drop: " + drop.gameObject.name);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject aux = collision.gameObject.
        typeEnemy = collision.gameObject.GetComponent<NewHero>();
        if (typeEnemy is NewHero)
        {
            Debug.Log("is enemy");
            
            typeEnemy.Hurt(STR);
        }
        // if (collision.gameObject.GetType() == typeof(NewEnemyGround))
        // {
        //     Debug.Log("choco enemigo");
        //     // Destroy(collision.gameObject);
        //     // GameManager.Instance.MinusEnemy();
        //     Destroy(gameObject);
        // }
        // if(collision.gameObject.layer == 9)
        // {
        //     //GameManager.Instance.BossDmg();
        //     Destroy(gameObject);
        //   
        // }
    }
    
    
    
    
    
    
}
