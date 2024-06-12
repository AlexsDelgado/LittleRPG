using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    private int Coins;
    private TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        Coins = 0;
        GameManager.Instance.sumCoins.AddListener(drawCoins);
        textMesh.text = $"{Coins}";
    }

    // Update is called once per frame
    void Update()
    {
        //Coins += Time.deltaTime;
        
    }

    public void drawCoins()
    {
        //Debug.Log("entro al drawCoins");
        Coins++;
        textMesh.text = $"{Coins}";
        //Coins++;
        //textMesh.text = Coins.ToString();
       
    }
}
