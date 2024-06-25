using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NewHero : MonoBehaviour
{

    private UnitStat UNIT;
    private int MaxHP;
    private int HP;
    private int STR;
    private int DEF;
    public NewMovement movimiento;
    public Animator animator;
    public GameObject arrowPrefab;
    private Vector3 direction;
    private int arrowDirection;
    private float arrowCooldown=0;
    private float attackSpeed = 1.5f;
    
    
    //scritableObject stats
    public void LoadStats()
    {
        MaxHP = UNIT.MaxHP;
        HP = UNIT.HP;
        STR = UNIT.STR;
        DEF = UNIT.DEF;
        movimiento.speed = UNIT.SPD;

    }

    public void ChangeAttackSpeed(float change)
    {
        attackSpeed = attackSpeed - change;
    }
    // Start is called before the first frame update
    void Start()
    {
        movimiento = GetComponent<NewMovement>();
        animator = GetComponent<Animator>();
    }
    

    // Update is called once per frame
    void Update()
    {
        arrowCooldown += Time.deltaTime;
        if (arrowCooldown>=attackSpeed)
        {
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
}
