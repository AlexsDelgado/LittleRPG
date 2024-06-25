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
    
    //scritableObject stats
    public void LoadStats()
    {
        MaxHP = UNIT.MaxHP;
        HP = UNIT.HP;
        STR = UNIT.STR;
        DEF = UNIT.DEF;
        movimiento.speed = UNIT.SPD;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("attack melee");
        }
        
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("bow attack right");
            animator.SetTrigger("attack_right");
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("bow attack left");
            animator.SetTrigger("attack_left");
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("bow attack up");
            animator.SetTrigger("attack_up");
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("bow attack down");
            animator.SetTrigger("attack_down");
        }
        
        animator.SetFloat("Horizontal", movimiento.l_horizontal);
        animator.SetFloat("Vertical", movimiento.l_vertical);
        animator.SetFloat("Speed", new Vector2(movimiento.l_horizontal, movimiento.l_vertical).sqrMagnitude);
    }
}
