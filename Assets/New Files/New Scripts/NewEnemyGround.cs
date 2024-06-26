using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
        HP = HP - dmg;
        Debug.Log("Pego " + HP);
        if (HP <= 0)
        {
            Destroy(gameObject);
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
