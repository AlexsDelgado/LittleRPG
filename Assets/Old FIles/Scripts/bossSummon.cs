using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSummon : MonoBehaviour
{
    [SerializeField] private GameObject Boss;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Hero player = collision.gameObject.GetComponent<Hero>();
            if (player)
            {
                Boss.gameObject.SetActive(true);
                GameManager.Instance.agregarEnemigo.Invoke();

            }
        }
    }

      
}
