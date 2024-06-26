using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    
    protected int MaxHP;
    protected int HP;
    protected int STR;
    protected int DEF;
    protected Animator animator;

    public virtual void Death() {}
    public virtual void Hurt() {}
}
