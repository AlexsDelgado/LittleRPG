using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public static HUD HUD_Instance;
    public GameObject[] Hearts;
    public GameObject[] HeartsDMG;
    public int health = 3;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI enemiesText;

  

    

    public int Coins;

    public int Enemies;



    private void Awake()
    {
        if (HUD_Instance == null)
        {
            HUD_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {


        //win/lose
        
        GameManager.Instance.win.AddListener(endCanvas);
        GameManager.Instance.lose.AddListener(endCanvas);

        //hearths
        GameManager.Instance.damage.AddListener(changeLife);


        //coins
        coinText = coinText.GetComponent<TextMeshProUGUI>();
        Coins = 0;
        GameManager.Instance.sumCoins.AddListener(drawCoins);
        GameManager.Instance.useCoin.AddListener(buyItem);
        coinText.text = $"{Coins}";


        //enemies
        GameManager.Instance.killEnemy.AddListener(enemiesLeft);
        GameManager.Instance.agregarEnemigo.AddListener(addEnemy);
        enemiesText = enemiesText.GetComponent<TextMeshProUGUI>();
        enemiesText.text = $"{Enemies}";

    }   
    // Update is called once per frame
    void Update()
    {
     
    }

    public void endCanvas()
    {
        Destroy(gameObject);
    }


    public void heal()
    {
        health++;
        switch (health)
        {
            case 2:
                Hearts[1].gameObject.SetActive(true);
                HeartsDMG[0].gameObject.SetActive(false);

                break;
            case 3:
                Hearts[2].gameObject.SetActive(true);
                HeartsDMG[1].gameObject.SetActive(false);
                break;
        }
    }
    public void changeLife()
    {
        health--;

        if (health < 2)
        {
            //Destroy(Hearts[1].gameObject);
            Hearts[1].gameObject.SetActive(false);
            HeartsDMG[0].gameObject.SetActive(true);
        }
        else if (health < 3)
        {
            //Destroy(Hearts[2].gameObject);
            Hearts[2].gameObject.SetActive(false);
            HeartsDMG[1].gameObject.SetActive(true);
        }
    }


    public void buyItem()
    {
      
    }
    public void drawCoins()
    {
   
        Coins++;
        coinText.text = $"{Coins}";


    }
    public void enemiesLeft()
    {
        
        Enemies--;
        enemiesText.text = $"{Enemies}";
    }
    public void addEnemy()
    {
      
        Enemies++;
        enemiesText.text = $"{Enemies}";

    }
}
