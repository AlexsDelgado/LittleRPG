using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NewHero : Unit
{
    [SerializeField] private  UnitStat UNIT;
    private NewMovement movimiento;
    [SerializeField] private GameObject arrowPrefab;
    private Vector3 direction;
    private int arrowDirection;
    private float arrowCooldown=0;
    private float attackSpeed = 1.5f;
    [SerializeField] private float hitRadio;
    [SerializeField] private Transform hitController;
    private Unit typeEnemy;
    private IHealthCanvasProvider _healthCanvasProvider;
    private IStatsCanvasProvider _statsCanvasProvider;
    
    void Start()
    {
        _healthCanvasProvider = MainCanvas.Instance;
        _statsCanvasProvider = MainCanvas.Instance;
        movimiento = GetComponent<NewMovement>();
        animator = GetComponent<Animator>();
        LoadStats();
        _statsCanvasProvider.StatsCanvas.UpdateStats(STR, DEF, (int)movimiento.speed, attackSpeed);
    }
    
    //scritableObject stats
    public void LoadStats()
    {
        MaxHP = UNIT.MaxHP;
        HP = UNIT.HP;
        STR = UNIT.STR;
        DEF = UNIT.DEF;
        movimiento.speed = UNIT.SPD;
    }

    /*public void ChangeAttackSpeed(float change)
    {
        attackSpeed = attackSpeed - change;
    }*/
    
    void Update()
    {
        arrowCooldown += Time.deltaTime;
        
        
        if (arrowCooldown>=attackSpeed)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                //Punch();
                Debug.Log("melee attack");
                animator.SetTrigger("melee");
                arrowCooldown = 0;
                
                Collider2D[] meleeAttack = Physics2D.OverlapCircleAll(hitController.position, hitRadio);
                foreach (Collider2D collider in meleeAttack)
                {
                    typeEnemy = collider.gameObject.GetComponent<NewEnemyGround>();
                    if (typeEnemy is NewEnemyGround)
                    {
                        Debug.Log("Bat");
                        typeEnemy.Hurt(STR);
                    }
                }
            }
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                
                Debug.Log(HP);
                Hurt(1);
                Debug.Log(HP);
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("attack melee");
            }
        
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("bow attack right");
                animator.SetTrigger("attack_right");
                arrowCooldown= 0;
                direction = new Vector3(1, 0, 0);
                arrowDirection = 3;
            }
        
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("bow attack left");
                animator.SetTrigger("attack_left");
                arrowCooldown = 0;
                direction = new Vector3(-1, 0, 0);
                arrowDirection = 4;
            }
        
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("bow attack up");
                animator.SetTrigger("attack_up");
                arrowCooldown = 0;
                direction = new Vector3(0, 1, 0);
                arrowDirection = 1;
            }
        
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("bow attack down");
                animator.SetTrigger("attack_down");
                arrowCooldown = 0;
                direction = new Vector3(0, -1, 0);
                arrowDirection = 2;
            }
        }
       
        
        animator.SetFloat("Horizontal", movimiento.l_horizontal);
        animator.SetFloat("Vertical", movimiento.l_vertical);
        animator.SetFloat("Speed", new Vector2(movimiento.l_horizontal, movimiento.l_vertical).sqrMagnitude);
    }

    public void ShootUp()
    {
        GameObject arrow = Instantiate(arrowPrefab, transform.position + direction, transform.rotation);
        arrow.GetComponent<NewArrow>().SetDirection(direction, arrowDirection); 
    }

    public override void Death()
    {
        Destroy(gameObject);
        Debug.Log("muerte jugador");
    }

    public override void Hurt(int dmg)
    {
        int dmgFinal = calculateDamage(dmg);
        HP = HP - dmgFinal;
        Debug.Log("dmg final: "+dmgFinal);
        Debug.Log("vida actual : "+HP);
        _healthCanvasProvider.HealthCanvas.UpdateHealth(HP, MaxHP);
        animator.SetTrigger("hurt");
        if (HP <= 0)
        {
            Death();
        } 
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(hitController.position, hitRadio);
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawWireCube(hitController.position, new Vector3(hitRadio, 1, 1));
        // Gizmos.color = Color.cyan;
        // Gizmos.DrawWireCube(hitController.position, new Vector3(hitRadio, 1, 1));
    }
    
    public void Heal(int HPToHeal)
    {
        HP += HPToHeal;
        if (HP > MaxHP)
        {
            HP = MaxHP;
        }
        _healthCanvasProvider.HealthCanvas.UpdateHealth(HP, MaxHP);
    }

    public void Buff(int _STR, int _DEF, int _SPD, float _AS)
    {
        STR += _STR;
        DEF += _DEF;
        movimiento.speed += _SPD;
        attackSpeed -= _AS;
        _statsCanvasProvider.StatsCanvas.UpdateStats(STR, DEF, (int)movimiento.speed, attackSpeed);
    }
}
