using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBossSummon : MonoBehaviour
{
    [SerializeField] private GameObject bossPrefab;
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            bossPrefab.gameObject.SetActive(true);
           
        }
    }
}
