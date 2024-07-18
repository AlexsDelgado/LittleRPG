using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float diagonalSpeedCap=0.6f;
    private float l_horizontal;
    private float l_vertical;
    //public Transform parent;
   
    

    void FixedUpdate()
    {
         l_horizontal = Input.GetAxis("Horizontal");
         l_vertical = Input.GetAxis("Vertical");
        //ok 1
        //  if(l_horizontal!=0 && l_vertical!=0)
        // { 
        //     l_horizontal = l_horizontal/ 2;
        //     l_vertical = l_vertical/ 2;
        // }
        DiagonalMovement();
        transform.position += new Vector3(l_horizontal, l_vertical,0) * speed * Time.deltaTime;
    }

    public void SetSpeed(float spd)
    {
        speed = spd;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public float GetVerticalAxis()
    {
        return l_vertical;
    }
    public float GetHorizontalAxis()
    {
        return l_horizontal;
    }
    private void DiagonalMovement()
    {
        if(l_horizontal>0 && l_vertical>0)
        {
            l_horizontal = diagonalSpeedCap;
            l_vertical = diagonalSpeedCap;
        }
        if(l_horizontal<0 && l_vertical>0)
        {
            l_horizontal = -diagonalSpeedCap;
            l_vertical = diagonalSpeedCap;
        }
        if(l_horizontal>0 && l_vertical<0)
        {
            l_horizontal = diagonalSpeedCap;
            l_vertical = -diagonalSpeedCap;
        }
        if(l_horizontal<0 && l_vertical<0)
        {
            l_horizontal = -diagonalSpeedCap;
            l_vertical = -diagonalSpeedCap;
        } 
    }

   
}
