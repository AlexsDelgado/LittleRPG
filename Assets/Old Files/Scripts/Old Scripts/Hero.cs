using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    
   //nombre
    public string CharacterName;
    [SerializeField] public int Life;
    public Movement movementComponent;
    


    


    //flechas y disparos
    public GameObject flechaPrefab;
    public Animator animator;
    public int bulletAmount = 10;
    public float fireRate = 1f;
    private float m_currentTime;
    private Vector3 direccion;
    private int arrowDirection;
    public float delayFlecha;

    private void Death()
    {
        //desaparece el pj
        gameObject.SetActive(false);
        GameManager.Instance.endGame();
        
    }


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Life = GameManager.Instance.m_health;
       // GameManager.Instance.AddHealth();
        GameManager.Instance.damage.AddListener(Hurt);
        GameManager.Instance.lose.AddListener(Death);
        GameManager.Instance.win.AddListener(Death);

    }

    // Update is called once per frame
    void Update()
    {
        m_currentTime += Time.deltaTime;

        //left
        if (Input.GetButton("Fire1") && m_currentTime > fireRate)
        {
            m_currentTime = 0;
            direccion = new Vector3(-1, 0, 0);
            arrowDirection = 4;

            //animacion
            animator.SetTrigger("attack_left");
       
            //GameObject flecha = Instantiate(flechaPrefab, transform.position + direccion, transform.rotation);
            //flecha.GetComponent<Arrow>().SetDirection(direccion, arrowDirection);
        }
        //right
        if (Input.GetButton("Fire2") && m_currentTime > fireRate)
        {
            m_currentTime = 0;
            direccion = new Vector3(1, 0, 0);
            arrowDirection = 3;
            animator.SetTrigger("attack_right");
         
            //GameObject flecha = Instantiate(flechaPrefab, transform.position + direccion, transform.rotation);
            //flecha.GetComponent<Arrow>().SetDirection(direccion, arrowDirection);
        }
        //up
        if (Input.GetButton("Fire3") && m_currentTime > fireRate)
        {
            m_currentTime = 0;
            direccion = new Vector3(0, 1, 0);
            arrowDirection = 1;
            animator.SetTrigger("attack_up");
  
            //GameObject flecha = Instantiate(flechaPrefab, transform.position + direccion, transform.rotation);
            //flecha.GetComponent<Arrow>().SetDirection(direccion, arrowDirection);

        }
        //down
        if (Input.GetButton("Fire4") && m_currentTime > fireRate)
        {

            m_currentTime = 0;
            direccion = new Vector3(0, -1, 0);
            arrowDirection = 2;
            animator.SetTrigger("attack_down");
            
            //GameObject flecha = Instantiate(flechaPrefab, transform.position + direccion, transform.rotation);
            //flecha.GetComponent<Arrow>().SetDirection(direccion, arrowDirection);
        }
    }

    public void ShootUp()
    {
     
        GameObject flecha = Instantiate(flechaPrefab, transform.position + direccion, transform.rotation);
        flecha.GetComponent<Arrow>().SetDirection(direccion, arrowDirection);

    }

    public void Hurt()
    {
      
        animator.SetTrigger("hurt");
        GetComponent<AudioSource>().Play();
        

    }
}
