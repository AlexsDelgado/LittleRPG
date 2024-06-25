using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class NewArrow : MonoBehaviour
{
    [SerializeField] private float m_speed;
    private Vector3 m_direction;
    [SerializeField] private float lifeTime = 2f;
    private float m_currentTime;
    public LayerMask objetivo;
    public UnityEvent arrow = new UnityEvent();

    public void SetDirection(Vector3 p_direction, int arrowDirection)
    {
        m_direction = p_direction;
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
        if (collision.GetType() == typeof(Enemy)) ;
        {
            Debug.Log("choco enemigo");
            // Destroy(collision.gameObject);
            // GameManager.Instance.MinusEnemy();
            Destroy(gameObject);
        }
        if(collision.gameObject.layer == 9)
        {
            //GameManager.Instance.BossDmg();
            Destroy(gameObject);
          
        }
    }
}

