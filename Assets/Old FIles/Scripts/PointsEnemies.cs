using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsEnemies : MonoBehaviour
{
    private int Enemies =0;
    private TextMeshProUGUI textMesh;
    // Start is called before the first frame update


  
    public void Start()
    {
        //GameManager.Instance.sumEnemy.AddListener(addEnemy);
        GameManager.Instance.killEnemy.AddListener(enemiesLeft);
        GameManager.Instance.agregarEnemigo.AddListener(addEnemy);
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text = $"{Enemies}";
    }

    public void enemiesLeft()
    {
        //Debug.Log("entro al enemiesLeft");
        Enemies--;
        textMesh.text = $"{Enemies}";
        //Coins++;
        //textMesh.text = Coins.ToString();
    }
    public void addEnemy()
    {
        Debug.Log("entro al addEnemy");
        Debug.Log(Enemies);
        Enemies++;
        textMesh.text = $"{Enemies}";
       
    }

}