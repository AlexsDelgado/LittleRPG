using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NewArrow : MonoBehaviour
{
    [SerializeField] private float m_speed;
    private Vector3 m_direction;
    [SerializeField] private float lifeTime = 2f;
    private Unit typeEnemy;
    private float m_currentTime;
    private int damage = 0;


  

    public void SetArrow(Vector3 p_direction, int arrowDirection,int _dmg)
    {
        m_direction = p_direction;
        damage = _dmg;
        switch (arrowDirection)
        {
            case 1:
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 2:
                transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case 3:
                transform.rotation = Quaternion.Euler(0, 0, -90);
                break;
            case 4:
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
        }
    }
    void Update()
    {
        m_currentTime += Time.deltaTime;
        if(m_currentTime > lifeTime)
        {
            Destroy(gameObject);
        }
        
        transform.position += m_speed * Time.deltaTime * m_direction;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject aux = collision.gameObject.
        typeEnemy = collision.gameObject.GetComponent<Unit>();
        if (typeEnemy is NewBossEnemy)
        {
            Destroy(gameObject);
            typeEnemy.Hurt(damage);
        }
        if (typeEnemy is NewEnemyGround)
        {
            Destroy(gameObject);
            typeEnemy.Hurt(damage);
        }
    }
}

