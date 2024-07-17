using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    //[SerializeField]
  

    protected int MaxHP;
    protected int HP;
    protected int STR;
    protected int DEF;
    protected Animator animator;
    protected bool canAttack =true;
    protected AudioClip hurtSound;
    
    protected Color newColor;
    protected float colorCD;
    protected Color colorActual;
    protected Color colorAuxiliar;
    protected SpriteRenderer rend;
    protected float animationCD = 0.2f;
    protected float invincibleTime = 1.5f;

 

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
    
    
    public virtual IEnumerator NewColor()
    {
        yield return new WaitForSeconds(colorCD);
    }

    // public virtual IEnumerator HurtAnimationColor()
    // {
    //     yield return new WaitForSeconds(0.2f);
    // }
    public IEnumerator HurtAnimationColor()
    {
        
        colorActual = rend.material.color;
        // newColor = new Color(colorActual.r, colorActual.g, colorActual.b, 1f);
        newColor = new Color(255, 0, 0, 1f);
        colorAuxiliar = new Color(colorActual.r, colorActual.g, colorActual.b, 0.6f);
      
        rend.material.color = colorAuxiliar;
        yield return new WaitForSeconds(animationCD);
        rend.material.color = newColor;

        yield return new WaitForSeconds(animationCD);
        rend.material.color = colorAuxiliar;
        yield return new WaitForSeconds(animationCD);
        rend.material.color = newColor;

        rend.material.color = colorAuxiliar;
        yield return new WaitForSeconds(animationCD);
        rend.material.color = colorActual;
    }
    public IEnumerator UnableCollider()
    {
        canAttack = false;
        //Physics2D.IgnoreLayerCollision(3, 7, true);
        yield return new WaitForSeconds(invincibleTime);
       // Physics2D.IgnoreLayerCollision(3, 7, false);
        canAttack = true;
    }
}
