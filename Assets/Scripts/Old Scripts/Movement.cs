using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{



    public float speed;
    public Animator animator;
    Vector2 movement;
    Rigidbody2D rb2d;
    public float l_horizontal;
    public float l_vertical;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        l_horizontal = Input.GetAxis("Horizontal");
        l_vertical = Input.GetAxis("Vertical");

        rb2d.MovePosition(rb2d.position + new Vector2(l_horizontal, l_vertical) * speed * Time.deltaTime);
    }

    void Update()
    {



        animator.SetFloat("Horizontal", l_horizontal);
        animator.SetFloat("Vertical", l_vertical);
        animator.SetFloat("Speed", new Vector2(l_horizontal, l_vertical).sqrMagnitude);
    }
}

