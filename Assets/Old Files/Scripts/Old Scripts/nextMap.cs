using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextMap : MonoBehaviour
{

    public GameObject[] obstaculos;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.nextLevel.AddListener(openNextLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void openNextLevel()
    {
        for (int i = 0; i < obstaculos.Length; i++)
        {
            obstaculos[i].SetActive(false);
        }
        gameObject.SetActive(false);
       
    }
}
