using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tutorial : MonoBehaviour
{

    public TextMeshProUGUI tutorialText;
    public GameObject icon;


    // Start is called before the first frame update
    void Start()
    {
        tutorialText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Debug.Log("entro al trigger");
            //tutorialText.gameObject.SetActive(true);

            tutorialText.text = "Dispara con las flechas del teclado";
            icon.SetActive(true);

        }
    }


}
