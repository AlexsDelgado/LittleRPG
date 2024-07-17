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
    protected AudioClip hurtSound;

    public virtual void Death() {}
    public virtual void Hurt(int dmg) {}

    public int calculateDamage(int dmg)
    {
        Debug.Log("Pego desde unit base " + dmg);
        int damageFinal = dmg - DEF;
        if (damageFinal> 0)
        {
            return damageFinal;
        }
        else
        {
            return 0;
        }
    }
}
