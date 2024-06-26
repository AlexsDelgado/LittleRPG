using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NewPatrolZone : MonoBehaviour
{
    public Transform startPosition;
    public Transform endPosition;
    public NewEnemyGround enemy;
    public Vector2 enemyPosition;
    

    //[Range(0, 3f)]
    public float radio = 0.2f;
    private void Update()
    {
        if (enemy != null)
        {
            if (enemy.chase==false)
            {
                if(Mathf.Approximately(enemyPosition.x, startPosition.position.x))
                {
                
                    enemy.right = true;
                }
                if(Mathf.Approximately(enemyPosition.x, endPosition.position.x))
                {
                
                    enemy.right = false;
                }
                enemyPosition = enemy.transform.position;
                if (enemyPosition.x > startPosition.position.x && enemy.right==false)
                {
                    //mover hacia la izq(start)
                    enemy.transform.localScale= new Vector3(-4, 3, 1);
                    enemy.transform.position = Vector2.MoveTowards(
                        enemy.transform.position,
                        startPosition.position,
                        Time.deltaTime*enemy.GetSPD());
                }
                if (enemyPosition.x < endPosition.position.x && enemy.right==true)
                {
                    //mover hacia la der(end)
                    enemy.transform.localScale= new Vector3(4, 3, 1);
                    enemy.transform.position = Vector2.MoveTowards(
                        enemy.transform.position,
                        endPosition.position,
                        Time.deltaTime*enemy.GetSPD()
                    );
                }
            }
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("colisiono afuera");
        // if (collision.GetType() == typeof(NewHero))
        // {
        //     Debug.Log("colisiono new hero");
        //     enemy.chase = true;
        //     enemy.SetTarget(collision.gameObject);
        // }


        if (collision.gameObject.GetType() == typeof(NewHero))
        {
            Debug.Log("is new hero");
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 end = endPosition.position;
        Vector3 start = startPosition.position;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(start,radio);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(end, radio);
        
    }
}
