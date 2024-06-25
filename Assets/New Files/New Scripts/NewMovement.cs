using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    public float speed;
    public float l_horizontal;
    public float l_vertical;
    public Transform parent;
   
    

    void FixedUpdate()
    {
        //parent = GetComponentInParent<Transform>();
         l_horizontal = Input.GetAxis("Horizontal");
         l_vertical = Input.GetAxis("Vertical");
        
        transform.position += new Vector3(l_horizontal, l_vertical,0) * speed * Time.deltaTime;
    }

   
}
