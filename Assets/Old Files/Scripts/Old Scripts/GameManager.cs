using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    [SerializeField] private GameObject Hero;
    [SerializeField] private int maxHealth;
   
    
    [SerializeField] public int m_health;
    [SerializeField] public int m_coins;
    [SerializeField] public int m_enemies;
    [SerializeField] public int m_arrows;

    public UnityEvent lose = new UnityEvent();
    public UnityEvent win = new UnityEvent();
    public UnityEvent damage = new UnityEvent();
 
    public UnityEvent sumCoins = new UnityEvent();
    public UnityEvent killEnemy = new UnityEvent();
    public UnityEvent arrow = new UnityEvent();
    

    public UnityEvent bossDMG = new UnityEvent();

    public UnityEvent agregarEnemigo = new UnityEvent();
    public UnityEvent menu = new UnityEvent();
    public UnityEvent play = new UnityEvent();

    public UnityEvent nextLevel = new UnityEvent();
    public UnityEvent useCoin = new UnityEvent();




    public void resetGame()
    {
        m_arrows = 0;
        m_coins = 0;
        m_health = maxHealth;
        m_enemies = 0;

    }

    public void endGame()
    {
        Destroy(gameObject);

    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);                                                       
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddCoin(Coin coin)
    {
        coin.OnCoinGrab.AddListener(GrabCoin);
        //m_coins++;
    }
    public void AddHealth()
    {
        m_health++;
    }
    public void getDamage()
    {
        damage.Invoke();
        m_health--;
        if (m_health <= 0)
        {
            lose.Invoke();
        }
        //Lose();
    }
    public void AddArrows()
    {
        m_arrows++;


    }
    public void useArrow()
    {
        m_arrows--;
        arrow.Invoke();
    }
    public void MinusEnemy()
    {
        killEnemy.Invoke();
        m_enemies--;
        if (m_enemies == 0)
        {
            nextLevel.Invoke();
        }
    }
    public void GrabCoin()
    {
        sumCoins.Invoke();
        m_coins++;
        //m_coins--;
        //if (m_coins == 0)
        //{
        //    nextLevel.Invoke();
        //}
    }
    public void AddEnemy(Enemy enemy)
    {
        //agregarEnemigo.Invoke();
        enemy.hitPlayer.AddListener(getDamage);
        m_enemies++;
    }
    public void AddEnemy()
    {

    }


    public void BossDmg()
    {
        //Boss.GetComponent<EnemyRangedAttack>().getDamage();
        bossDMG.Invoke();
    }

    public void buyItem(int price)
    {
        m_coins -= price;
        useCoin.Invoke();

    }

}
